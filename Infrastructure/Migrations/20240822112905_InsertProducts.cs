using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("72305704-41a0-412c-a64e-d4832035585f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e41fc9b6-3673-40aa-ba27-fa5cc62ba9a8"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedOnUtc", "Category", "Description", "Price", "Quantity", "Sku", "Title" },
                values: new object[,]
                {
                    { new Guid("72305704-41a0-412c-a64e-d4832035585f"), new DateTime(2024, 8, 21, 6, 5, 47, 619, DateTimeKind.Utc).AddTicks(9365), 0, "This is a sony headphones description", 700.5, 5L, "S0K462HYLS", "Sony" },
                    { new Guid("e41fc9b6-3673-40aa-ba27-fa5cc62ba9a8"), new DateTime(2024, 8, 21, 6, 5, 47, 619, DateTimeKind.Utc).AddTicks(9372), 3, "This is a LED lamp which used for lightning", 50.0, 5L, "KOP1ESOSE3", "Lamp" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
