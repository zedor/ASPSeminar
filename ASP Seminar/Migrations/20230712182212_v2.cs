using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Seminar.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8584982f-3be7-4b35-a4fc-14d2fa00c5ef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ca38518-9079-4bda-83db-fd6367f14e6a", "4644a99c-f4d1-438c-b393-aa0e01d88841", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "LRF" },
                    { 2, "HRF" },
                    { 3, "Udica" },
                    { 4, "Stap" },
                    { 5, "Jig" },
                    { 6, "Najlon" },
                    { 7, "Upredenica" },
                    { 8, "Olovo" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, "Sharpest hook in the shed.", 3.90m, 15m, "Udica 1/0" },
                    { 2, "Sharpest hook in the shed.", 3.90m, 25m, "Udica 2/0" },
                    { 3, "Sharpest hook in the shed.", 3.90m, 17m, "Udica 4/0" },
                    { 4, "Sharpest hook in the shed.", 3.90m, 23m, "Udica 2" },
                    { 5, "Sharpest hook in the shed.", 3.90m, 12m, "Udica 4" },
                    { 6, "Mostly for jigging, action 25-50g", 79.9m, 7m, "Jigmaher 5000" },
                    { 7, "Mostly for jigging, action 15-25g", 69.9m, 2m, "Jigmaher 3000" },
                    { 8, "Mostly for jigging, action 5-15g", 59.9m, 0m, "Jigmaher 2000" },
                    { 9, "Grounded design! Action 20-50g", 65m, 5m, "Fermaher 50" },
                    { 10, "Grounded design! Action 40-70g", 75m, 3m, "Fermaher 60" },
                    { 11, "Grounded design! Action 60-120g", 95m, 3m, "Fermaher 70" },
                    { 12, "Float like a butterfly, fish in the sea. 3.0m", 52m, 4m, "Plovakher 10" },
                    { 13, "Float like a butterfly, fish in the sea. 3.7m", 59m, 2m, "Plovakher 11" },
                    { 14, "Float like a butterfly, fish in the sea. 4.0m", 69m, 1m, "Plovakher 12" },
                    { 15, "Float like a butterfly, fish in the sea. 4.2m", 85m, 1m, "Plovakher 13" },
                    { 16, "Durable, better than the rest!", 8.9m, 12m, "Monolayn .17 Ultra" },
                    { 17, "Durable, better than the rest!", 8.9m, 15m, "Monolayn .22 Ultra" },
                    { 18, "Durable, better than the rest!", 8.9m, 9m, "Monolayn .25 Ultra" },
                    { 19, "Durable, better than the rest!", 9.9m, 8m, "Monolayn .28 Ultra" },
                    { 20, "Durable, better than the rest!", 9.9m, 10m, "Monolayn .35 Ultra" },
                    { 21, "Durable, better than the rest!", 12.9m, 5m, "Monolayn .40 Ultra" },
                    { 22, "Durable!", 6.9m, 13m, "Monolayn .16 Mid" },
                    { 23, "Durable!", 7.9m, 12m, "Monolayn .235 Mid" },
                    { 24, "For tournaments and recreational use.", 18.25m, 7m, "Shpagodenica #.4 Pro X8" },
                    { 25, "For tournaments and recreational use.", 18.25m, 6m, "Shpagodenica #.6 Pro X8" },
                    { 26, "For tournaments and recreational use.", 22.25m, 7m, "Shpagodenica #.8 Pro X8" },
                    { 27, "For tournaments and recreational use.", 24.25m, 4m, "Shpagodenica #1 Pro X8" },
                    { 28, "For recreational use.", 14.25m, 9m, "Shpagodenica #.6 X4" },
                    { 29, "For recreational use.", 15.25m, 4m, "Shpagodenica #.8 X4" },
                    { 30, "For recreational use.", 16.25m, 5m, "Shpagodenica #1 X4" },
                    { 31, "Floats to the bottom.", 0.5m, 15m, "Olovnica Teary 5g" },
                    { 32, "Floats to the bottom.", 0.5m, 12m, "Olovnica Teary 10g" },
                    { 33, "Floats to the bottom.", 0.5m, 14m, "Olovnica Teary 15g" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Price", "Quantity", "Title" },
                values: new object[] { 34, "Sinks like a small rock.", 1m, 11m, "Olovnica Diamonde 25g" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Price", "Quantity", "Title" },
                values: new object[] { 35, "Sinks like a small rock.", 1m, 7m, "Olovnica Diamonde 30g" });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 2, 3, 2 },
                    { 3, 3, 3 },
                    { 4, 3, 4 },
                    { 5, 3, 5 },
                    { 6, 4, 6 },
                    { 7, 4, 7 },
                    { 8, 4, 8 },
                    { 9, 4, 9 },
                    { 10, 4, 10 },
                    { 11, 4, 11 },
                    { 12, 4, 12 },
                    { 13, 4, 13 },
                    { 14, 4, 14 },
                    { 15, 4, 15 },
                    { 16, 6, 16 },
                    { 17, 6, 17 },
                    { 18, 6, 18 },
                    { 19, 6, 19 },
                    { 20, 6, 20 },
                    { 21, 6, 21 },
                    { 22, 6, 22 },
                    { 23, 6, 23 },
                    { 24, 7, 24 },
                    { 25, 7, 25 },
                    { 26, 7, 26 },
                    { 27, 7, 27 },
                    { 28, 7, 28 },
                    { 29, 7, 29 },
                    { 30, 7, 30 },
                    { 31, 8, 31 },
                    { 32, 8, 32 },
                    { 33, 8, 33 },
                    { 34, 8, 34 },
                    { 35, 8, 35 },
                    { 36, 5, 6 },
                    { 37, 5, 7 },
                    { 38, 5, 8 },
                    { 39, 1, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ca38518-9079-4bda-83db-fd6367f14e6a");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8584982f-3be7-4b35-a4fc-14d2fa00c5ef", "00e7eb67-7bd1-4885-bcbc-ceeeb2b2d9b5", "Admin", "ADMIN" });
        }
    }
}
