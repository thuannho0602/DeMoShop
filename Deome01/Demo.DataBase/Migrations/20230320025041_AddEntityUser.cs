using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.DataBase.Migrations
{
    public partial class AddEntityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 20, 9, 50, 40, 872, DateTimeKind.Local).AddTicks(9771),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 20, 9, 35, 44, 851, DateTimeKind.Local).AddTicks(8003));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("30c3c812-22c7-41ee-8b82-b6d2ea0ae6cd"), "5400e2da-18d4-4ab1-b572-5fe567bdd288", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("1bf6041a-0963-4eb7-bbdc-0ab25b0e301d"), 0, "ac7e4249-9c38-4a6c-bf82-c509202358b5", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "thuannho0602@gmail.com", true, "THuan", "Nguyen", false, null, "thuannho0602@gmail.com", "admin", "AQAAAAEAACcQAAAAEOg67clfmft7SmLTZk2VxzlyYiaXonZhtF8ZZuQhLeczvymCZsGPD+Qiq2JrOyMZEw==", null, false, "", false, "admin" });

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

            migrationBuilder.InsertData(
                table: "Slide",
                columns: new[] { "Id", "Description", "Image", "Name", "SortOrder", "Status", "Url" },
                values: new object[,]
                {
                    { 1, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/1.png", "Second Thumbnail label", 1, 1, "#" },
                    { 2, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/2.png", "Second Thumbnail label", 2, 1, "#" },
                    { 3, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/3.png", "Second Thumbnail label", 3, 1, "#" },
                    { 4, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/4.png", "Second Thumbnail label", 4, 1, "#" },
                    { 5, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/5.png", "Second Thumbnail label", 5, 1, "#" },
                    { 6, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/6.png", "Second Thumbnail label", 6, 1, "#" }
                });

            migrationBuilder.InsertData(
                table: "appUserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("30c3c812-22c7-41ee-8b82-b6d2ea0ae6cd"), new Guid("1bf6041a-0963-4eb7-bbdc-0ab25b0e301d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("30c3c812-22c7-41ee-8b82-b6d2ea0ae6cd"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("1bf6041a-0963-4eb7-bbdc-0ab25b0e301d"));

            migrationBuilder.DeleteData(
                table: "Slide",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Slide",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Slide",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Slide",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Slide",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Slide",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "appUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("30c3c812-22c7-41ee-8b82-b6d2ea0ae6cd"), new Guid("1bf6041a-0963-4eb7-bbdc-0ab25b0e301d") });

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 20, 9, 35, 44, 851, DateTimeKind.Local).AddTicks(8003),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 20, 9, 50, 40, 872, DateTimeKind.Local).AddTicks(9771));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreacted",
                value: new DateTime(2023, 3, 20, 9, 35, 44, 854, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreacted",
                value: new DateTime(2023, 3, 20, 9, 35, 44, 854, DateTimeKind.Local).AddTicks(3822));
        }
    }
}
