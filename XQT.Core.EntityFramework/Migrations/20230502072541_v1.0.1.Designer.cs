﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XQT.Core.EntityFramework;

#nullable disable

namespace XQT.Core.EntityFramework.Migrations
{
    [DbContext(typeof(XQTContext))]
    [Migration("20230502072541_v1.0.1")]
    partial class v101
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("XQT.Core.Model.MenuEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Icon")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("图标");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("bit")
                        .HasComment("是否隐藏");

                    b.Property<bool>("IsOpenWindow")
                        .HasColumnType("bit")
                        .HasComment("是否开启新窗口");

                    b.Property<string>("MenuCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("菜单编码");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("菜单名称");

                    b.Property<string>("MenuPath")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("权限地址");

                    b.Property<int>("MenuType")
                        .HasColumnType("int")
                        .HasComment("菜单类型");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModifiedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<long>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Remark")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("备注");

                    b.Property<string>("RoutePath")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("路由地址");

                    b.Property<long?>("TenantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("sys_menu", null, t =>
                        {
                            t.HasComment("菜单表");
                        });

                    b.HasData(
                        new
                        {
                            Id = 123989081921L,
                            CreatedTime = new DateTime(2023, 5, 2, 15, 25, 41, 360, DateTimeKind.Local).AddTicks(5822),
                            CreatedUserId = 123123123L,
                            CreatedUserName = "admin",
                            IsDeleted = false,
                            IsHidden = false,
                            IsOpenWindow = false,
                            MenuCode = "",
                            MenuName = "系统管理",
                            MenuPath = "",
                            MenuType = 0,
                            ParentId = 0L,
                            RoutePath = ""
                        },
                        new
                        {
                            Id = 123989081922L,
                            CreatedTime = new DateTime(2023, 5, 2, 15, 25, 41, 360, DateTimeKind.Local).AddTicks(5829),
                            CreatedUserId = 123123123L,
                            CreatedUserName = "admin",
                            IsDeleted = false,
                            IsHidden = false,
                            IsOpenWindow = false,
                            MenuCode = "",
                            MenuName = "用户管理",
                            MenuPath = "/api/user/getpage",
                            MenuType = 1,
                            ParentId = 123989081921L,
                            RoutePath = "system/user"
                        });
                });

            modelBuilder.Entity("XQT.Core.Model.RoleEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("角色编码");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bit")
                        .HasComment("是否启用");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModifiedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("角色名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("备注");

                    b.Property<int?>("Sort")
                        .HasColumnType("int")
                        .HasComment("排序");

                    b.Property<long?>("TenantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("sys_role", null, t =>
                        {
                            t.HasComment("角色表");
                        });

                    b.HasData(
                        new
                        {
                            Id = 12312534123L,
                            Code = "admin",
                            CreatedTime = new DateTime(2023, 5, 2, 15, 25, 41, 360, DateTimeKind.Local).AddTicks(3397),
                            CreatedUserId = 123123123L,
                            CreatedUserName = "admin",
                            IsDeleted = false,
                            IsEnable = true,
                            Name = "超级管理员",
                            Sort = 1
                        });
                });

            modelBuilder.Entity("XQT.Core.Model.RoleMenuEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<long>("MenuId")
                        .HasColumnType("bigint")
                        .HasComment("菜单Id");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasComment("角色Id");

                    b.HasKey("Id");

                    b.ToTable("sys_role_menu", null, t =>
                        {
                            t.HasComment("角色菜单表");
                        });
                });

            modelBuilder.Entity("XQT.Core.Model.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("AvatarId")
                        .HasColumnType("bigint")
                        .HasComment("头像Id");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("邮箱");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModifiedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NickName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("昵称");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("密码");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("手机号码");

                    b.Property<string>("Remark")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("备注");

                    b.Property<long?>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("用户名");

                    b.Property<int>("UserStatus")
                        .HasColumnType("int")
                        .HasComment("用户状态");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("sys_user", null, t =>
                        {
                            t.HasComment("用户表");
                        });

                    b.HasData(
                        new
                        {
                            Id = 123123123L,
                            CreatedTime = new DateTime(2023, 5, 2, 15, 25, 41, 361, DateTimeKind.Local).AddTicks(40),
                            CreatedUserId = 123123123L,
                            CreatedUserName = "admin",
                            IsDeleted = false,
                            Password = "E10ADC3949BA59ABBE56E057F20F883E",
                            UserName = "admin",
                            UserStatus = 1
                        });
                });

            modelBuilder.Entity("XQT.Core.Model.UserRoleEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasComment("角色Id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasComment("用户Id");

                    b.HasKey("Id");

                    b.ToTable("sys_user_role", null, t =>
                        {
                            t.HasComment("用户角色表");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1231209887L,
                            CreatedTime = new DateTime(2023, 5, 2, 15, 25, 41, 361, DateTimeKind.Local).AddTicks(1770),
                            CreatedUserId = 123123123L,
                            CreatedUserName = "admin",
                            RoleId = 12312534123L,
                            UserId = 123123123L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
