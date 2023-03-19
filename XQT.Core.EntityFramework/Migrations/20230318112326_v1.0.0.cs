using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XQT.Core.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class v100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sys_role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "角色名称"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "角色编码"),
                    Remark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "备注"),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false, comment: "是否启用"),
                    Sort = table.Column<int>(type: "int", nullable: true, comment: "排序"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role", x => x.Id);
                },
                comment: "角色表");

            migrationBuilder.CreateTable(
                name: "sys_user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "用户名"),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "密码"),
                    NickName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "昵称"),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "邮箱"),
                    UserStatus = table.Column<int>(type: "int", nullable: false, comment: "用户状态"),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "手机号码"),
                    AvatarId = table.Column<long>(type: "bigint", nullable: false, comment: "头像Id"),
                    Remark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "备注"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user", x => x.Id);
                },
                comment: "用户表");

            migrationBuilder.CreateTable(
                name: "sys_user_role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "用户Id"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false, comment: "角色Id"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user_role", x => x.Id);
                },
                comment: "用户角色表");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_role");

            migrationBuilder.DropTable(
                name: "sys_user");

            migrationBuilder.DropTable(
                name: "sys_user_role");
        }
    }
}
