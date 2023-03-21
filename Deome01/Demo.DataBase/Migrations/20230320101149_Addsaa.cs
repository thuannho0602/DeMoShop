using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.DataBase.Migrations
{
    public partial class Addsaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Product_ProductId",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "ProductImage");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImage",
                newName: "IX_ProductImage_ProductId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 20, 9, 50, 40, 872, DateTimeKind.Local).AddTicks(9771));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Product_ProductId",
                table: "ProductImage",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Product_ProductId",
                table: "ProductImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage");

            migrationBuilder.RenameTable(
                name: "ProductImage",
                newName: "ProductImages");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 20, 9, 50, 40, 872, DateTimeKind.Local).AddTicks(9771),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("30c3c812-22c7-41ee-8b82-b6d2ea0ae6cd"),
                column: "ConcurrencyStamp",
                value: "5400e2da-18d4-4ab1-b572-5fe567bdd288");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("1bf6041a-0963-4eb7-bbdc-0ab25b0e301d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ac7e4249-9c38-4a6c-bf82-c509202358b5", "AQAAAAEAACcQAAAAEOg67clfmft7SmLTZk2VxzlyYiaXonZhtF8ZZuQhLeczvymCZsGPD+Qiq2JrOyMZEw==" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreacted",
                value: new DateTime(2023, 3, 20, 9, 50, 40, 876, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreacted",
                value: new DateTime(2023, 3, 20, 9, 50, 40, 876, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Product_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
