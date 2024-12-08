using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    AddressLine = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Elektrogitar", "elektrogitar" },
                    { 2, "Kulaklık", "kulaklık" },
                    { 3, "Bilgisayar", "bilgisayar" },
                    { 4, "Kasa", "kasa" },
                    { 5, "Klavye", "klavye" },
                    { 6, "Mouse", "mouse" },
                    { 7, "Anakart", "anakart" },
                    { 8, "Ram", "ram" },
                    { 9, "Power", "power" },
                    { 10, "Gpu", "gpu" },
                    { 11, "Cpu", "cpu" },
                    { 12, "Fan", "fan" },
                    { 13, "Ssd", "ssd" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "nota", "Ibanez-1", 15000m },
                    { 2, "nota", "Ibanez-2", 20000m },
                    { 3, "nota", "Ibanez-3", 30000m },
                    { 4, "nota", "Ibanez-4", 40000m },
                    { 5, "nota", "Ibanez-5", 50000m },
                    { 6, "nota", "Ibanez-6", 60000m },
                    { 7, "nota", "Ibanez-11", 11000m },
                    { 8, "nota", "Ibanez-21", 21000m },
                    { 9, "nota", "Ibanez-31", 31000m },
                    { 10, "nota", "Ibanez-41", 41000m },
                    { 11, "nota", "Ibanez-51", 51000m },
                    { 12, "nota", "Ibanez-61", 61000m },
                    { 13, "mouse", "Mouse-1", 2000m },
                    { 14, "gpu", "Gpu-2", 7000m },
                    { 15, "cpu", "Cpu-3", 8000m },
                    { 16, "cpu", "Cpu-4", 9000m },
                    { 17, "power", "Power-5", 4000m },
                    { 18, "power", "Power-6", 5000m },
                    { 19, "ram", "Ram-11", 4000m },
                    { 20, "ram", "Ram-21", 5000m },
                    { 21, "anakart", "Anakart-31", 11000m },
                    { 22, "anakart", "Anakart-41", 21000m },
                    { 23, "fan", "Fan-51", 1200m },
                    { 24, "ssd", "Ssd-61", 1000m },
                    { 25, "bilgisayar", "Bilgisayar-1", 105000m },
                    { 26, "bilgisayar", "Bilgisayar-2", 200000m },
                    { 27, "kasa", "Kasa-3", 60000m },
                    { 28, "kasa", "Kasa-4", 80000m },
                    { 29, "klavye", "Klavye-5", 4000m },
                    { 30, "klavye", "Klavye-6", 8000m },
                    { 31, "mouse", "Mouse-11", 11000m },
                    { 32, "ssd", "Ssd-21", 7500m },
                    { 33, "kasa", "Kasa-31", 50000m },
                    { 34, "kasa", "Kasa-41", 45000m },
                    { 35, "kulaklık", "Kulaklık-51", 8000m },
                    { 36, "kulaklık", "Kulaklık-61", 6000m },
                    { 37, "kulaklık", "Kulaklık-62", 2000m },
                    { 38, "fan", "Fan-2", 7000m },
                    { 39, "fan", "Fan-3", 8000m },
                    { 40, "cpu", "Cpu-4", 9000m }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 2, 35 },
                    { 2, 36 },
                    { 2, 37 },
                    { 3, 25 },
                    { 3, 26 },
                    { 4, 27 },
                    { 4, 28 },
                    { 4, 33 },
                    { 4, 34 },
                    { 5, 29 },
                    { 5, 30 },
                    { 6, 13 },
                    { 6, 31 },
                    { 7, 21 },
                    { 7, 22 },
                    { 8, 19 },
                    { 8, 20 },
                    { 9, 17 },
                    { 9, 18 },
                    { 10, 14 },
                    { 11, 15 },
                    { 11, 16 },
                    { 11, 40 },
                    { 12, 23 },
                    { 12, 38 },
                    { 12, 39 },
                    { 13, 24 },
                    { 13, 32 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Url",
                table: "Categories",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
