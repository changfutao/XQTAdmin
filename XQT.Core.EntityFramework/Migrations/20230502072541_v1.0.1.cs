using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XQT.Core.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class v101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsButton",
                table: "sys_menu");

            migrationBuilder.AlterColumn<string>(
                name: "MenuCode",
                table: "sys_menu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "菜单编码",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "菜单编码");

            migrationBuilder.AddColumn<int>(
                name: "MenuType",
                table: "sys_menu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "菜单类型");

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "sys_menu",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "sys_menu",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "CreatedUserName", "Icon", "IsDeleted", "IsHidden", "IsOpenWindow", "MenuCode", "MenuName", "MenuPath", "MenuType", "ModifiedTime", "ModifiedUserId", "ModifiedUserName", "ParentId", "Remark", "RoutePath", "TenantId" },
                values: new object[,]
                {
                    { 123989081921L, new DateTime(2023, 5, 2, 15, 25, 41, 360, DateTimeKind.Local).AddTicks(5822), 123123123L, "admin", null, false, false, false, "", "系统管理", "", 0, null, null, null, 0L, null, "", null },
                    { 123989081922L, new DateTime(2023, 5, 2, 15, 25, 41, 360, DateTimeKind.Local).AddTicks(5829), 123123123L, "admin", null, false, false, false, "", "用户管理", "/api/user/getpage", 1, null, null, null, 123989081921L, null, "system/user", null }
                });

            migrationBuilder.InsertData(
                table: "sys_role",
                columns: new[] { "Id", "Code", "CreatedTime", "CreatedUserId", "CreatedUserName", "IsDeleted", "IsEnable", "ModifiedTime", "ModifiedUserId", "ModifiedUserName", "Name", "Remark", "Sort", "TenantId" },
                values: new object[] { 12312534123L, "admin", new DateTime(2023, 5, 2, 15, 25, 41, 360, DateTimeKind.Local).AddTicks(3397), 123123123L, "admin", false, true, null, null, null, "超级管理员", null, 1, null });

            migrationBuilder.UpdateData(
                table: "sys_user",
                keyColumn: "Id",
                keyValue: 123123123L,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 2, 15, 25, 41, 361, DateTimeKind.Local).AddTicks(40));

            migrationBuilder.InsertData(
                table: "sys_user_role",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "CreatedUserName", "RoleId", "UserId" },
                values: new object[] { 1231209887L, new DateTime(2023, 5, 2, 15, 25, 41, 361, DateTimeKind.Local).AddTicks(1770), 123123123L, "admin", 12312534123L, 123123123L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 123989081921L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 123989081922L);

            migrationBuilder.DeleteData(
                table: "sys_role",
                keyColumn: "Id",
                keyValue: 12312534123L);

            migrationBuilder.DeleteData(
                table: "sys_user_role",
                keyColumn: "Id",
                keyValue: 1231209887L);

            migrationBuilder.DropColumn(
                name: "MenuType",
                table: "sys_menu");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "sys_menu");

            migrationBuilder.AlterColumn<string>(
                name: "MenuCode",
                table: "sys_menu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "菜单编码",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "菜单编码");

            migrationBuilder.AddColumn<bool>(
                name: "IsButton",
                table: "sys_menu",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "是否按钮");

            migrationBuilder.UpdateData(
                table: "sys_user",
                keyColumn: "Id",
                keyValue: 123123123L,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 4, 20, 24, 13, 741, DateTimeKind.Local).AddTicks(7664));
        }
    }
}
