﻿// <auto-generated />
using System;
using AirSoft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirSoft.Data.Migrations
{
    [DbContext(typeof(AirSoftDbContext))]
    [Migration("20211202103811_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AirSoft.Data.Entity.DbUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", "dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fadde9ec-7dc4-4033-b1e6-2f83a08c70f3"),
                            AddedDate = new DateTime(2021, 12, 2, 1, 50, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = new Guid("fadde9ec-7dc4-4033-b1e6-2f83a08c70f3"),
                            Email = "khoruzhenko.work@gmail.com",
                            ModifiedBy = new Guid("fadde9ec-7dc4-4033-b1e6-2f83a08c70f3"),
                            ModifiedDate = new DateTime(2021, 12, 2, 1, 50, 0, 0, DateTimeKind.Unspecified),
                            PasswordHash = "AQAAAAEAACcQAAAAEMQnvSxDqgyc+KNNzIFjcuST/qZGfHVSLT9P+Z3revJP2Q9Tctz8PIeDxj2k7aJkLg==",
                            Phone = "89266762453"
                        });
                });

            modelBuilder.Entity("AirSoft.Data.Entity.DbUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Role = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Role = "Organizer"
                        },
                        new
                        {
                            Id = 3,
                            Role = "TeamLeader"
                        },
                        new
                        {
                            Id = 4,
                            Role = "Sponsor"
                        },
                        new
                        {
                            Id = 5,
                            Role = "Merchant"
                        },
                        new
                        {
                            Id = 6,
                            Role = "Private"
                        },
                        new
                        {
                            Id = 8,
                            Role = "User"
                        });
                });

            modelBuilder.Entity("AirSoft.Data.Entity.DbUsersToRoles", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UsersToRoles", "dbo");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("fadde9ec-7dc4-4033-b1e6-2f83a08c70f3"),
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("AirSoft.Data.Entity.DbUsersToRoles", b =>
                {
                    b.HasOne("AirSoft.Data.Entity.DbUserRole", "Role")
                        .WithMany("UsersToRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirSoft.Data.Entity.DbUser", "User")
                        .WithMany("UsersToRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AirSoft.Data.Entity.DbUser", b =>
                {
                    b.Navigation("UsersToRoles");
                });

            modelBuilder.Entity("AirSoft.Data.Entity.DbUserRole", b =>
                {
                    b.Navigation("UsersToRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
