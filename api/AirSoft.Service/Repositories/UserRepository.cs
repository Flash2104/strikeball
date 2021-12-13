﻿using AirSoft.Data;
using AirSoft.Data.Entity;
using AirSoft.Service.Common;
using AirSoft.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AirSoft.Service.Repositories;

public class UserRepository : GenericRepository<DbUser>
{
    public UserRepository(IDbContext context) : base(context)
    {
    }

    public async Task<DbUser?> GetByPhoneAsync(string phone)
    {
        var users = await ListAsync(e => e.Phone == phone);
        var dbUsers = users.ToList();
        if (dbUsers.Count > 1)
        {
            throw new AirSoftBaseException(ErrorCodes.UserRepository.MoreThanOneUserByPhone,
                "В базе больше одного пользователя по данному номеру телефона.");
        }

        return dbUsers.FirstOrDefault();
    }

    public async Task<DbUser?> GetByEmailAsync(string email)
    {
        var users = await ListAsync(e => e.Email == email);
        var dbUsers = users.ToList();
        if (dbUsers.Count > 1)
        {
            throw new AirSoftBaseException(ErrorCodes.UserRepository.MoreThanOneUserByEmail,
                "В базе больше одного пользователя по данному email.");
        }

        return dbUsers.FirstOrDefault();
    }

    public async Task<List<DbUserRole>> GetRolesWithNavigationsAsync(Guid userId)
    {
        var dbUser = await _context!.Users!
            .Include(x => x.UserRoles)!
            .ThenInclude(x => x.UserNavigation)
            .FirstOrDefaultAsync(x => x.Id == userId);
        if (dbUser == null )
        {
            throw new AirSoftBaseException(ErrorCodes.UserRepository.UserNotFound,
                "Пользователь не найден.");
        }
        return dbUser.UserRoles!.ToList();
    }

    public DbUser? CreateDbUser(DbUser user)
    {
        return Insert(user);
    }
}