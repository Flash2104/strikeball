﻿
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirSoft.Data.Entity;

public class DbUser
{
    public DbUser()
    {
    }

    private DbUser(ILazyLoader lazyLoader)
    {
        LazyLoader = lazyLoader;
    }

    private ILazyLoader LazyLoader { get; set; } = null!;

    private ICollection<DbUserRole>? _userRoles;

    public Guid Id { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? PasswordHash { get; set; }

    public ICollection<DbUserRole>? UserRoles
    {
        get => LazyLoader.Load(this, ref _userRoles);
        set => _userRoles = value;
    }

    public virtual List<DbUsersToRoles>? UsersToRoles { get; set; }

    public virtual DbMember? Member { get; set; }

    public string HashPassword(string password)
    {
        var ph = new PasswordHasher<DbUser>();
        return ph.HashPassword(this, password);
    }

    public bool ValidPassword(string password)
    {
        var ph = new PasswordHasher<DbUser>();
        var result = ph.VerifyHashedPassword(this, PasswordHash, password);
        return result == PasswordVerificationResult.Success;
    }
}

internal sealed class DbUserMapping
{
    public void Map(EntityTypeBuilder<DbUser> builder, Guid userId)
    {
        builder.ToTable("Users");

        builder.HasKey(x => new { x.Id });
        builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(255);
        builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(50);
        builder.Property(x => x.ModifiedDate).IsRequired().HasMaxLength(50);

        var admin = new DbUser
        {
            Id = userId,
            CreatedDate = new DateTime(2021, 12, 02, 1, 50, 00),
            ModifiedDate = new DateTime(2021, 12, 02, 1, 50, 00),
            CreatedBy = userId,
            ModifiedBy = userId,
            Email = "khoruzhenko.work@gmail.com",
            PasswordHash = "AQAAAAEAACcQAAAAEMQnvSxDqgyc+KNNzIFjcuST/qZGfHVSLT9P+Z3revJP2Q9Tctz8PIeDxj2k7aJkLg==",
            Phone = "89266762453"
        };
        builder.HasData(admin);
        builder.HasMany(x => x.UserRoles).WithMany(x => x.Users).UsingEntity<DbUsersToRoles>(
            x => x.HasData(new DbUsersToRoles()
            {
                UserId = userId,
                RoleId = (int) UserRoleType.Creator
            })
            );
    }
}
