using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XQT.Core.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class v101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "sys_user",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "密码",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "密码");

            migrationBuilder.AlterColumn<long>(
                name: "AvatarId",
                table: "sys_user",
                type: "bigint",
                nullable: true,
                comment: "头像Id",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "头像Id");

            migrationBuilder.InsertData(
                table: "sys_user",
                columns: new[] { "Id", "AvatarId", "CreatedTime", "CreatedUserId", "CreatedUserName", "Email", "IsDeleted", "ModifiedTime", "ModifiedUserId", "ModifiedUserName", "NickName", "Password", "Phone", "Remark", "TenantId", "UserName", "UserStatus" },
                values: new object[] { 123123123L, null, new DateTime(2023, 3, 18, 19, 33, 22, 365, DateTimeKind.Local).AddTicks(4014), 123123123L, "admin", null, false, null, null, null, null, "E10ADC3949BA59ABBE56E057F20F883E", null, null, null, "admin", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "sys_user",
                keyColumn: "Id",
                keyValue: 123123123L);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "sys_user",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "密码",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "密码");

            migrationBuilder.AlterColumn<long>(
                name: "AvatarId",
                table: "sys_user",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "头像Id",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true,
                oldComment: "头像Id");
        }
    }
}
