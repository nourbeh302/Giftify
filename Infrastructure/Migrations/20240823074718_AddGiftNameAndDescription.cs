using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGiftNameAndDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Gifts",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Gifts",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Gifts");

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
        }
    }
}
