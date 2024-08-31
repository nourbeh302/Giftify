using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("04b141e5-b3b1-4305-a72e-acb9b5619e7d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86dc53c1-7780-417e-b76f-d03f44dc9817"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a951375-d6fb-4711-ba7e-01e93c6df6f0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9b576432-964d-4040-81eb-a7877050288b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a84f50ce-d90d-416d-b610-4b7af68c92e8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("adf3dd50-26f0-489e-9e00-5958c132a9ba"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b51653ed-a9f8-4520-b55b-10a11bdeb089"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ba5869ac-2f68-4ce1-80e7-65afe091e3c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d05c041e-18ab-4b3c-ae25-de7b597e3343"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d45c76b3-8519-486b-997c-e4e5c844b3b4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d714cc29-1886-4e2f-ba96-a6b6e1f675b4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de825c15-6411-4b51-86a3-ef1f248793d2"));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderGifts",
                columns: table => new
                {
                    GiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderGifts", x => new { x.GiftId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderGifts_Gifts_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderGifts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedOnUtc", "Category", "Description", "Price", "Quantity", "Sku", "Title" },
                values: new object[,]
                {
                    { new Guid("3e9587d0-e0b9-41bc-bfd3-77eb6a0f201a"), new DateTime(2024, 8, 26, 14, 11, 28, 330, DateTimeKind.Utc).AddTicks(7560), 3, "A reliable dishwasher with efficient cleaning performance.", 799.99000000000001, 5L, "BOSH0010", "Bosch Dishwasher" },
                    { new Guid("3fa0aca1-d0e5-46a9-b17f-62a5a6ce8b87"), new DateTime(2024, 8, 26, 14, 11, 28, 330, DateTimeKind.Utc).AddTicks(7551), 0, "The latest gaming console from Sony.", 499.99000000000001, 5L, "PS50005", "PlayStation 5" },
                    { new Guid("4c269c81-de74-436f-b2f9-88a26e29fa88"), new DateTime(2024, 8, 26, 14, 11, 28, 330, DateTimeKind.Utc).AddTicks(7558), 0, "A high-quality QLED TV with excellent picture quality.", 1799.99, 5L, "SAMQ90B0009", "Samsung QLED TV QN90B" },
                    { new Guid("596f2769-689d-44d0-94aa-ae7912c0b029"), new DateTime(2024, 8, 26, 14, 11, 28, 330, DateTimeKind.Utc).AddTicks(7546), 0, "The latest flagship smartphone from Apple.", 1299.99, 5L, "IPH14P0001", "iPhone 14 Pro" },
                    { new Guid("654a7012-5c93-44cc-9a73-74b3726fa065"), new DateTime(2024, 8, 26, 14, 11, 28, 330, DateTimeKind.Utc).AddTicks(7553), 0, "A hybrid console with a high-resolution OLED screen.", 349.99000000000001, 5L, "NSO0007", "Nintendo Switch OLED" },
                    { new Guid("767e1270-f67c-4ca6-944b-c3295e2e8664"), new DateTime(2024, 8, 26, 14, 11, 28, 330, DateTimeKind.Utc).AddTicks(7552), 0, "A powerful gaming console from Microsoft.", 499.99000000000001, 5L, "XSX0006", "Xbox Series X" },
                    { new Guid("932575f9-f6aa-48d1-9d7a-dc53eba6dea2"), new DateTime(2024, 8, 26, 14, 11, 28, 330, DateTimeKind.Utc).AddTicks(7549), 0, "A high-performance laptop powered by the M2 chip.", 1699.99, 5L, "MBP0004", "MacBook Pro M2" },
                    { new Guid("bd465539-3909-46f9-9315-113892cc59c0"), new DateTime(2024, 8, 26, 14, 11, 28, 330, DateTimeKind.Utc).AddTicks(7528), 0, "This is a sony headphones description", 700.5, 5L, "S0K462HYLS", "Sony" },
                    { new Guid("c1d219fb-adb8-4186-86ca-8e1ca5def797"), new DateTime(2024, 8, 26, 14, 11, 28, 330, DateTimeKind.Utc).AddTicks(7547), 0, "A powerful Android smartphone with advanced features.", 1199.99, 5L, "SGS23U0002", "Samsung Galaxy S23 Ultra" },
                    { new Guid("cdda476d-18ce-4ebc-a9a6-ee30664fc39f"), new DateTime(2024, 8, 26, 14, 11, 28, 330, DateTimeKind.Utc).AddTicks(7548), 0, "A premium laptop with a sleek design and powerful performance.", 1499.99, 5L, "DXPS130003", "Dell XPS 13" },
                    { new Guid("e4c79d75-8e5b-449d-9789-13b859382619"), new DateTime(2024, 8, 26, 14, 11, 28, 330, DateTimeKind.Utc).AddTicks(7554), 0, "A high-quality OLED TV with stunning picture quality.", 1999.99, 5L, "LGTVC20008", "LG OLED TV C2 Series" },
                    { new Guid("ff30fb81-0507-4e42-9e75-e222fb5b24ce"), new DateTime(2024, 8, 26, 14, 11, 28, 330, DateTimeKind.Utc).AddTicks(7535), 3, "This is a LED lamp which used for lightning", 50.0, 5L, "KOP1ESOSE3", "Lamp" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderGifts_OrderId",
                table: "OrderGifts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderGifts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3e9587d0-e0b9-41bc-bfd3-77eb6a0f201a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3fa0aca1-d0e5-46a9-b17f-62a5a6ce8b87"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4c269c81-de74-436f-b2f9-88a26e29fa88"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("596f2769-689d-44d0-94aa-ae7912c0b029"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("654a7012-5c93-44cc-9a73-74b3726fa065"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("767e1270-f67c-4ca6-944b-c3295e2e8664"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("932575f9-f6aa-48d1-9d7a-dc53eba6dea2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bd465539-3909-46f9-9315-113892cc59c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c1d219fb-adb8-4186-86ca-8e1ca5def797"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cdda476d-18ce-4ebc-a9a6-ee30664fc39f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e4c79d75-8e5b-449d-9789-13b859382619"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ff30fb81-0507-4e42-9e75-e222fb5b24ce"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedOnUtc", "Category", "Description", "Price", "Quantity", "Sku", "Title" },
                values: new object[,]
                {
                    { new Guid("04b141e5-b3b1-4305-a72e-acb9b5619e7d"), new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7655), 3, "A reliable dishwasher with efficient cleaning performance.", 799.99000000000001, 5L, "BOSH0010", "Bosch Dishwasher" },
                    { new Guid("86dc53c1-7780-417e-b76f-d03f44dc9817"), new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7646), 0, "A powerful gaming console from Microsoft.", 499.99000000000001, 5L, "XSX0006", "Xbox Series X" },
                    { new Guid("8a951375-d6fb-4711-ba7e-01e93c6df6f0"), new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7631), 0, "This is a sony headphones description", 700.5, 5L, "S0K462HYLS", "Sony" },
                    { new Guid("9b576432-964d-4040-81eb-a7877050288b"), new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7645), 0, "The latest gaming console from Sony.", 499.99000000000001, 5L, "PS50005", "PlayStation 5" },
                    { new Guid("a84f50ce-d90d-416d-b610-4b7af68c92e8"), new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7642), 0, "A powerful Android smartphone with advanced features.", 1199.99, 5L, "SGS23U0002", "Samsung Galaxy S23 Ultra" },
                    { new Guid("adf3dd50-26f0-489e-9e00-5958c132a9ba"), new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7652), 0, "A high-quality OLED TV with stunning picture quality.", 1999.99, 5L, "LGTVC20008", "LG OLED TV C2 Series" },
                    { new Guid("b51653ed-a9f8-4520-b55b-10a11bdeb089"), new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7651), 0, "A hybrid console with a high-resolution OLED screen.", 349.99000000000001, 5L, "NSO0007", "Nintendo Switch OLED" },
                    { new Guid("ba5869ac-2f68-4ce1-80e7-65afe091e3c9"), new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7643), 0, "A premium laptop with a sleek design and powerful performance.", 1499.99, 5L, "DXPS130003", "Dell XPS 13" },
                    { new Guid("d05c041e-18ab-4b3c-ae25-de7b597e3343"), new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7644), 0, "A high-performance laptop powered by the M2 chip.", 1699.99, 5L, "MBP0004", "MacBook Pro M2" },
                    { new Guid("d45c76b3-8519-486b-997c-e4e5c844b3b4"), new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7653), 0, "A high-quality QLED TV with excellent picture quality.", 1799.99, 5L, "SAMQ90B0009", "Samsung QLED TV QN90B" },
                    { new Guid("d714cc29-1886-4e2f-ba96-a6b6e1f675b4"), new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7640), 0, "The latest flagship smartphone from Apple.", 1299.99, 5L, "IPH14P0001", "iPhone 14 Pro" },
                    { new Guid("de825c15-6411-4b51-86a3-ef1f248793d2"), new DateTime(2024, 8, 23, 7, 47, 17, 684, DateTimeKind.Utc).AddTicks(7638), 3, "This is a LED lamp which used for lightning", 50.0, 5L, "KOP1ESOSE3", "Lamp" }
                });
        }
    }
}
