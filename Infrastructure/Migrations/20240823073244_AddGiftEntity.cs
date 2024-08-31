using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGiftEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("03147455-309e-4d2f-85b4-ba308e5e9904"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("04c9a5af-b1e3-4535-ac67-0f340ae9057c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11391204-3034-44ba-a39b-44b94e885483"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11f69943-9bf2-4117-bfa1-8047ecb5fa85"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4a30048f-74cc-4fd2-a6cb-c3f8a2f8b9fa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5109656e-ec93-49d0-b4b4-c685f56f54a7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("68aba4d7-3579-49f1-b113-2af56100b777"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("75699388-9ef6-44db-9564-c0c64b8470f5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("921db079-08a6-427b-8250-a009d71f10d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("923036f0-c8e6-401f-b26b-39f10184fa70"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1164f6e-12d9-4151-b68a-cd381e1f57e3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a81bff87-3947-41ef-910c-9ca604044999"));

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gifts_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiftProducts",
                columns: table => new
                {
                    GiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftProducts", x => new { x.GiftId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_GiftProducts_Gifts_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiftProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedOnUtc", "Category", "Description", "Price", "Quantity", "Sku", "Title" },
                values: new object[,]
                {
                    { new Guid("2e9c0385-c3b8-4ea7-a811-0dddca2b43d5"), new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6883), 0, "A high-quality OLED TV with stunning picture quality.", 1999.99, 5L, "LGTVC20008", "LG OLED TV C2 Series" },
                    { new Guid("3a3cfb26-4de7-4642-a439-565d76dedc0d"), new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6847), 0, "This is a sony headphones description", 700.5, 5L, "S0K462HYLS", "Sony" },
                    { new Guid("4527d8f7-d933-4b94-93c9-d052386b732f"), new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6876), 0, "A high-performance laptop powered by the M2 chip.", 1699.99, 5L, "MBP0004", "MacBook Pro M2" },
                    { new Guid("4ac75600-cf55-482c-9d2d-15e640bd3d60"), new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6880), 0, "A hybrid console with a high-resolution OLED screen.", 349.99000000000001, 5L, "NSO0007", "Nintendo Switch OLED" },
                    { new Guid("55c7de33-9d0b-4763-b9f5-7132e82c0342"), new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6885), 0, "A high-quality QLED TV with excellent picture quality.", 1799.99, 5L, "SAMQ90B0009", "Samsung QLED TV QN90B" },
                    { new Guid("657c70f3-21b9-4165-b717-92d4b503ed84"), new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6874), 0, "A powerful Android smartphone with advanced features.", 1199.99, 5L, "SGS23U0002", "Samsung Galaxy S23 Ultra" },
                    { new Guid("8fa1e893-58c3-4658-afb5-f184d1209fa8"), new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6879), 0, "A powerful gaming console from Microsoft.", 499.99000000000001, 5L, "XSX0006", "Xbox Series X" },
                    { new Guid("96399555-f641-410c-b23c-f7218b910ea2"), new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6875), 0, "A premium laptop with a sleek design and powerful performance.", 1499.99, 5L, "DXPS130003", "Dell XPS 13" },
                    { new Guid("a1750acf-5fad-43b1-af89-c57a168ef37f"), new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6886), 3, "A reliable dishwasher with efficient cleaning performance.", 799.99000000000001, 5L, "BOSH0010", "Bosch Dishwasher" },
                    { new Guid("b5a79cf0-1abc-4558-bd41-391a9ba49aa0"), new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6872), 0, "The latest flagship smartphone from Apple.", 1299.99, 5L, "IPH14P0001", "iPhone 14 Pro" },
                    { new Guid("e3747d97-e312-449b-ab39-f70abf53fb79"), new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6878), 0, "The latest gaming console from Sony.", 499.99000000000001, 5L, "PS50005", "PlayStation 5" },
                    { new Guid("e6b07ca8-33ef-4285-b92c-4ba8f03b53bb"), new DateTime(2024, 8, 23, 7, 32, 44, 57, DateTimeKind.Utc).AddTicks(6870), 3, "This is a LED lamp which used for lightning", 50.0, 5L, "KOP1ESOSE3", "Lamp" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiftProducts_ProductId",
                table: "GiftProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_CreatedById",
                table: "Gifts",
                column: "CreatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiftProducts");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2e9c0385-c3b8-4ea7-a811-0dddca2b43d5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a3cfb26-4de7-4642-a439-565d76dedc0d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4527d8f7-d933-4b94-93c9-d052386b732f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4ac75600-cf55-482c-9d2d-15e640bd3d60"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("55c7de33-9d0b-4763-b9f5-7132e82c0342"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("657c70f3-21b9-4165-b717-92d4b503ed84"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8fa1e893-58c3-4658-afb5-f184d1209fa8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("96399555-f641-410c-b23c-f7218b910ea2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1750acf-5fad-43b1-af89-c57a168ef37f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b5a79cf0-1abc-4558-bd41-391a9ba49aa0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e3747d97-e312-449b-ab39-f70abf53fb79"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6b07ca8-33ef-4285-b92c-4ba8f03b53bb"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedOnUtc", "Category", "Description", "Price", "Quantity", "Sku", "Title" },
                values: new object[,]
                {
                    { new Guid("03147455-309e-4d2f-85b4-ba308e5e9904"), new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(600), 0, "The latest gaming console from Sony.", 499.99000000000001, 5L, "PS50005", "PlayStation 5" },
                    { new Guid("04c9a5af-b1e3-4535-ac67-0f340ae9057c"), new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(595), 0, "The latest flagship smartphone from Apple.", 1299.99, 5L, "IPH14P0001", "iPhone 14 Pro" },
                    { new Guid("11391204-3034-44ba-a39b-44b94e885483"), new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(604), 0, "A high-quality OLED TV with stunning picture quality.", 1999.99, 5L, "LGTVC20008", "LG OLED TV C2 Series" },
                    { new Guid("11f69943-9bf2-4117-bfa1-8047ecb5fa85"), new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(598), 0, "A premium laptop with a sleek design and powerful performance.", 1499.99, 5L, "DXPS130003", "Dell XPS 13" },
                    { new Guid("4a30048f-74cc-4fd2-a6cb-c3f8a2f8b9fa"), new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(607), 0, "A high-quality QLED TV with excellent picture quality.", 1799.99, 5L, "SAMQ90B0009", "Samsung QLED TV QN90B" },
                    { new Guid("5109656e-ec93-49d0-b4b4-c685f56f54a7"), new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(602), 0, "A powerful gaming console from Microsoft.", 499.99000000000001, 5L, "XSX0006", "Xbox Series X" },
                    { new Guid("68aba4d7-3579-49f1-b113-2af56100b777"), new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(581), 3, "This is a LED lamp which used for lightning", 50.0, 5L, "KOP1ESOSE3", "Lamp" },
                    { new Guid("75699388-9ef6-44db-9564-c0c64b8470f5"), new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(597), 0, "A powerful Android smartphone with advanced features.", 1199.99, 5L, "SGS23U0002", "Samsung Galaxy S23 Ultra" },
                    { new Guid("921db079-08a6-427b-8250-a009d71f10d3"), new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(609), 3, "A reliable dishwasher with efficient cleaning performance.", 799.99000000000001, 5L, "BOSH0010", "Bosch Dishwasher" },
                    { new Guid("923036f0-c8e6-401f-b26b-39f10184fa70"), new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(573), 0, "This is a sony headphones description", 700.5, 5L, "S0K462HYLS", "Sony" },
                    { new Guid("a1164f6e-12d9-4151-b68a-cd381e1f57e3"), new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(603), 0, "A hybrid console with a high-resolution OLED screen.", 349.99000000000001, 5L, "NSO0007", "Nintendo Switch OLED" },
                    { new Guid("a81bff87-3947-41ef-910c-9ca604044999"), new DateTime(2024, 8, 22, 11, 29, 5, 518, DateTimeKind.Utc).AddTicks(599), 0, "A high-performance laptop powered by the M2 chip.", 1699.99, 5L, "MBP0004", "MacBook Pro M2" }
                });
        }
    }
}
