using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.DataBase.Migrations
{
    public partial class AddColumData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppConfig",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { " Minh Thuan", "afdfdfvddfdds" },
                    { "Nguyen Minh ", "afdfdfds" },
                    { "Nguyen Minh Thuan", "afdfdfds" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "IsShowonHome", "ParentId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, true, null, 1, 1 },
                    { 2, true, null, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[,]
                {
                    { "en", false, "English" },
                    { "vi", true, "Tiếng Việt" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "DateCreacted", "IsFeaatured", "Originalprice", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 17, 17, 4, 17, 813, DateTimeKind.Local).AddTicks(6987), false, 10000m, 2000m },
                    { 2, new DateTime(2023, 3, 17, 17, 4, 17, 813, DateTimeKind.Local).AddTicks(7004), false, 10000m, 2000m }
                });

            migrationBuilder.InsertData(
                table: "CategoryTranslation",
                columns: new[] { "Id", "CategoryId", "LanguageId", "Name", "SeoAlias", "SeoDesCription", "SeoTile" },
                values: new object[,]
                {
                    { 1, 1, "vi", "Áo Nam", "Ao-Nam", "Sẩn Phẩm Thời Trang Nam ", "Sẩn Phẩm Thời Trang Nam" },
                    { 2, 2, "en", "Men-Shirt", "Men-Shirt", "Men's Fashion Products ", "Men's Fashion Products" }
                });

            migrationBuilder.InsertData(
                table: "ProcductInCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductTranslation",
                columns: new[] { "Id", "Description", "Details", "LanguageId", "Name", "ProductId", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, "Áo Sơ Mi Nam Trắng Minh Thuận", "Áo Sơ Mi Nam Trắng Minh Thuận", "vi", "Áo Sơ Mi Nam Trắng Minh Thuận", 1, "ao-so-mi-nam-trang-minh-thuan", "Áo Sơ Mi Nam Trắng Minh Thuận ", "Áo Sơ Mi Nam Trắng Minh Thuận" },
                    { 2, "Minh Thuan Men's White Shirt", "Minh Thuan Men's White Shirt", "en", "Minh Thuan Men's White Shirt", 2, "minh-thuan-men's-white-shirt", "Minh Thuan Men's White Shirt ", "Minh Thuan Men's White Shirt" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Key",
                keyValue: " Minh Thuan");

            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Key",
                keyValue: "Nguyen Minh ");

            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Key",
                keyValue: "Nguyen Minh Thuan");

            migrationBuilder.DeleteData(
                table: "CategoryTranslation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryTranslation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProcductInCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductTranslation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTranslation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "en");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "vi");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
