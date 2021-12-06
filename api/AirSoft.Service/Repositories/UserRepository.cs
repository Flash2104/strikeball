﻿using AirSoft.Data;
using AirSoft.Data.Entity;
using AirSoft.Service.Common;
using AirSoft.Service.Exceptions;

namespace AirSoft.Service.Repositories;

public class UserRepository: GenericRepository<DbUser>
{
    public UserRepository(IDbContext context) : base(context)
    {
    }

    public async Task<DbUser?> GetByPhoneAsync(string phone)
    {
        var users = await GetAsync(e => e.Phone == phone);
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
        var users = await GetAsync(e => e.Email == email);
        var dbUsers = users.ToList();
        if (dbUsers.Count > 1)
        {
            throw new AirSoftBaseException(ErrorCodes.UserRepository.MoreThanOneUserByPhone,
                "В базе больше одного пользователя по данному номеру телефона.");
        }

        return dbUsers.FirstOrDefault();
    }

    public DbUser? CreateDbUser(DbUser user)
    {
        return Insert(user);
    }
}