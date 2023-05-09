using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XQT.Core.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class v102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 123989081921L,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 9, 18, 7, 27, 128, DateTimeKind.Local).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 123989081922L,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 9, 18, 7, 27, 128, DateTimeKind.Local).AddTicks(3326));

            migrationBuilder.InsertData(
                table: "sys_menu",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "CreatedUserName", "Icon", "IsDeleted", "IsHidden", "IsOpenWindow", "MenuCode", "MenuName", "MenuPath", "MenuType", "ModifiedTime", "ModifiedUserId", "ModifiedUserName", "ParentId", "Remark", "RoutePath", "TenantId" },
                values: new object[] { 123989081923L, new DateTime(2023, 5, 9, 18, 7, 27, 128, DateTimeKind.Local).AddTicks(3329), 123123123L, "admin", null, false, false, false, "api:user:add", "添加", "", 2, null, null, null, 123989081922L, null, "", null });

            migrationBuilder.UpdateData(
                table: "sys_role",
                keyColumn: "Id",
                keyValue: 12312534123L,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 9, 18, 7, 27, 128, DateTimeKind.Local).AddTicks(859));

            migrationBuilder.UpdateData(
                table: "sys_user",
                keyColumn: "Id",
                keyValue: 123123123L,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 9, 18, 7, 27, 128, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "sys_user_role",
                keyColumn: "Id",
                keyValue: 1231209887L,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 9, 18, 7, 27, 128, DateTimeKind.Local).AddTicks(9082));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 123989081923L);

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 123989081921L,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 2, 15, 25, 41, 360, DateTimeKind.Local).AddTicks(5822));

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 123989081922L,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 2, 15, 25, 41, 360, DateTimeKind.Local).AddTicks(5829));

            migrationBuilder.UpdateData(
                table: "sys_role",
                keyColumn: "Id",
                keyValue: 12312534123L,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 2, 15, 25, 41, 360, DateTimeKind.Local).AddTicks(3397));

            migrationBuilder.UpdateData(
                table: "sys_user",
                keyColumn: "Id",
                keyValue: 123123123L,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 2, 15, 25, 41, 361, DateTimeKind.Local).AddTicks(40));

            migrationBuilder.UpdateData(
                table: "sys_user_role",
                keyColumn: "Id",
                keyValue: 1231209887L,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 2, 15, 25, 41, 361, DateTimeKind.Local).AddTicks(1770));
        }
    }
}
