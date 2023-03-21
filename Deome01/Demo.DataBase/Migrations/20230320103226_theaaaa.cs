using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.DataBase.Migrations
{
    public partial class theaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ProductImage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("30c3c812-22c7-41ee-8b82-b6d2ea0ae6cd"),
                column: "ConcurrencyStamp",
                value: "6d04c782-95ed-4dc6-bac3-0779d9ccc149");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("1bf6041a-0963-4eb7-bbdc-0ab25b0e301d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bf0b3adf-99fc-41c2-9151-2ba3f798ac9e", "AQAAAAEAACcQAAAAEKo4zQ6ZVK3e/Rq5hX59niPIetqWBZ3T4R7AH5eEU/7gnPwM+X+/Q11s5IDZuB89Gg==" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreacted",
                value: new DateTime(2023, 3, 20, 17, 32, 25, 527, DateTimeKind.Local).AddTicks(1149));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreacted",
                value: new DateTime(2023, 3, 20, 17, 32, 25, 527, DateTimeKind.Local).AddTicks(1159));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ProductImage");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("30c3c812-22c7-41ee-8b82-b6d2ea0ae6cd"),
                column: "ConcurrencyStamp",
                value: "3e6f9f1e-91cb-4279-ac79-bceef54d3f48");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("1bf6041a-0963-4eb7-bbdc-0ab25b0e301d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d7873aa1-2a2b-48cb-8c5b-bd2cbb22f74c", "AQAAAAEAACcQAAAAEMLM1k+zHJYPl6FpE9/RLpPnr22AvUaF9hM6fUoQ/hAtOMQV8tbq3ug71Af/TwlDGA==" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreacted",
                value: new DateTime(2023, 3, 20, 17, 11, 48, 325, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreacted",
                value: new DateTime(2023, 3, 20, 17, 11, 48, 325, DateTimeKind.Local).AddTicks(9617));
        }
    }
}
