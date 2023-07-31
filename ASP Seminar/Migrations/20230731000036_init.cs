using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Seminar.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    HasImage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BillingAddressId = table.Column<int>(type: "int", nullable: true),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_UserAddress_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "UserAddress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_UserAddress_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "UserAddress",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00c267e7-b325-4e7f-b151-03c5e5aa3c5f", "75ae35c0-7f57-4d57-aec5-2f0d1999c4ef", "User", "USER" },
                    { "8f2da973-f007-4416-9d07-d222793681dc", "ac338823-3955-4cb8-a725-4a2e9d2e5e67", "Admin", "ADMIN" }
                });

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
                columns: new[] { "Id", "Description", "HasImage", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, "Sharpest hook in the shed.", true, 3.90m, 15, "Udica 1/0" },
                    { 2, "Sharpest hook in the shed.", true, 3.90m, 25, "Udica 2/0" },
                    { 3, "Sharpest hook in the shed.", true, 3.90m, 17, "Udica 4/0" },
                    { 4, "Sharpest hook in the shed.", true, 3.90m, 23, "Udica 2" },
                    { 5, "Sharpest hook in the shed.", true, 3.90m, 12, "Udica 4" },
                    { 6, "Mostly for jigging, action 25-50g", true, 79.9m, 7, "Jigmaher 5000" },
                    { 7, "Mostly for jigging, action 15-25g", true, 69.9m, 2, "Jigmaher 3000" },
                    { 8, "Mostly for jigging, action 5-15g", true, 59.9m, 0, "Jigmaher 2000" },
                    { 9, "Grounded design! Action 20-50g", true, 65m, 5, "Fermaher 50" },
                    { 10, "Grounded design! Action 40-70g", true, 75m, 3, "Fermaher 60" },
                    { 11, "Grounded design! Action 60-120g", true, 95m, 3, "Fermaher 70" },
                    { 12, "Float like a butterfly, fish in the sea. 3.0m", true, 52m, 4, "Plovakher 10" },
                    { 13, "Float like a butterfly, fish in the sea. 3.7m", true, 59m, 2, "Plovakher 11" },
                    { 14, "Float like a butterfly, fish in the sea. 4.0m", true, 69m, 1, "Plovakher 12" },
                    { 15, "Float like a butterfly, fish in the sea. 4.2m", true, 85m, 1, "Plovakher 13" },
                    { 16, "Durable, better than the rest!", true, 8.9m, 12, "Monolayn .17 Ultra" },
                    { 17, "Durable, better than the rest!", true, 8.9m, 15, "Monolayn .22 Ultra" },
                    { 18, "Durable, better than the rest!", true, 8.9m, 9, "Monolayn .25 Ultra" },
                    { 19, "Durable, better than the rest!", true, 9.9m, 8, "Monolayn .28 Ultra" },
                    { 20, "Durable, better than the rest!", true, 9.9m, 10, "Monolayn .35 Ultra" },
                    { 21, "Durable, better than the rest!", true, 12.9m, 5, "Monolayn .40 Ultra" },
                    { 22, "Durable!", true, 6.9m, 13, "Monolayn .16 Mid" },
                    { 23, "Durable!", true, 7.9m, 12, "Monolayn .235 Mid" },
                    { 24, "For tournaments and recreational use.", true, 18.25m, 7, "Shpagodenica #.4 Pro X8" },
                    { 25, "For tournaments and recreational use.", true, 18.25m, 6, "Shpagodenica #.6 Pro X8" },
                    { 26, "For tournaments and recreational use.", true, 22.25m, 7, "Shpagodenica #.8 Pro X8" },
                    { 27, "For tournaments and recreational use.", true, 24.25m, 4, "Shpagodenica #1 Pro X8" },
                    { 28, "For recreational use.", true, 14.25m, 9, "Shpagodenica #.6 X4" },
                    { 29, "For recreational use.", true, 15.25m, 4, "Shpagodenica #.8 X4" },
                    { 30, "For recreational use.", true, 16.25m, 5, "Shpagodenica #1 X4" },
                    { 31, "Floats to the bottom.", true, 0.5m, 15, "Olovnica Teary 5g" },
                    { 32, "Floats to the bottom.", true, 0.5m, 12, "Olovnica Teary 10g" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "HasImage", "Price", "Quantity", "Title" },
                values: new object[] { 33, "Floats to the bottom.", true, 0.5m, 14, "Olovnica Teary 15g" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "HasImage", "Price", "Quantity", "Title" },
                values: new object[] { 34, "Sinks like a small rock.", true, 1m, 11, "Olovnica Diamonde 25g" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "HasImage", "Price", "Quantity", "Title" },
                values: new object[] { 35, "Sinks like a small rock.", true, 1m, 7, "Olovnica Diamonde 30g" });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BillingAddressId",
                table: "Order",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingAddressId",
                table: "Order",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserAddress");
        }
    }
}
