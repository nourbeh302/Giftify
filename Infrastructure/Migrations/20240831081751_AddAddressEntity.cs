using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0f852a3c-68bb-4124-aa9e-95c83dc23a83"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4df52493-9f22-42b0-a5ba-84b359403b5b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("56d0ccb5-de4a-4853-bdd6-0b2a2b351635"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("574ebadd-084e-4afd-808b-689e271026e7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6a1758ba-d604-4523-8b4a-f6c18030bde8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8aa8572f-b6c6-43aa-8742-0224ef73b35f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8f38ff7c-58c8-4b6c-9bb0-45182a5c32cf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9871859e-2ec9-40b9-9099-ff1cb1fb6276"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a0aef1de-687e-441a-8a42-c02c9bd0f938"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c02cb303-0f6e-4736-8957-8d007d25e4f8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c092a9d9-fac3-49b6-8fab-6b4bf90308d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e0267593-7492-4144-9557-75861cde7d98"));

            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "BillingAddressId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShippingAddressId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Building = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Governate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedOnUtc", "Category", "Description", "Price", "Quantity", "Sku", "Title" },
                values: new object[,]
                {
                    { new Guid("1be601ee-9054-4b5e-a233-bb0654f6f54f"), new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3252), 0, "A high-quality OLED TV with stunning picture quality.", 1999.99, 5L, "LGTVC20008", "LG OLED TV C2 Series" },
                    { new Guid("2e1c51ca-3243-464d-9f16-f6b985e28a7d"), new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3241), 0, "The latest flagship smartphone from Apple.", 1299.99, 5L, "IPH14P0001", "iPhone 14 Pro" },
                    { new Guid("39c95e72-cf33-44be-a93e-b9b6097c4324"), new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3229), 0, "This is a sony headphones description", 700.5, 5L, "S0K462HYLS", "Sony" },
                    { new Guid("60671684-b470-4ec7-8496-b7290c3469cc"), new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3254), 3, "A reliable dishwasher with efficient cleaning performance.", 799.99000000000001, 5L, "BOSH0010", "Bosch Dishwasher" },
                    { new Guid("69f7c992-b590-459d-8827-54dbe1493a87"), new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3240), 3, "This is a LED lamp which used for lightning", 50.0, 5L, "KOP1ESOSE3", "Lamp" },
                    { new Guid("6d138d7c-d6c4-41e8-8ecb-3e66ebe7b52a"), new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3253), 0, "A high-quality QLED TV with excellent picture quality.", 1799.99, 5L, "SAMQ90B0009", "Samsung QLED TV QN90B" },
                    { new Guid("7caf6b66-4108-4d38-9492-0a71ed80d7c1"), new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3246), 0, "The latest gaming console from Sony.", 499.99000000000001, 5L, "PS50005", "PlayStation 5" },
                    { new Guid("8e8d0322-5ce9-4178-91a1-e2c3aa6fd977"), new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3243), 0, "A powerful Android smartphone with advanced features.", 1199.99, 5L, "SGS23U0002", "Samsung Galaxy S23 Ultra" },
                    { new Guid("9eb262cd-df1d-4377-9727-7e33e42ba6c9"), new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3245), 0, "A high-performance laptop powered by the M2 chip.", 1699.99, 5L, "MBP0004", "MacBook Pro M2" },
                    { new Guid("beafb549-6a09-4fbd-8f27-9dbc44ec906c"), new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3251), 0, "A hybrid console with a high-resolution OLED screen.", 349.99000000000001, 5L, "NSO0007", "Nintendo Switch OLED" },
                    { new Guid("d2a2510f-8b37-4d31-a3ed-a7b645a29751"), new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3244), 0, "A premium laptop with a sleek design and powerful performance.", 1499.99, 5L, "DXPS130003", "Dell XPS 13" },
                    { new Guid("fe08feeb-c55a-4cd8-9130-e4ea1ee90a91"), new DateTime(2024, 8, 31, 8, 17, 51, 566, DateTimeKind.Utc).AddTicks(3248), 0, "A powerful gaming console from Microsoft.", 499.99000000000001, 5L, "XSX0006", "Xbox Series X" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingAddressId",
                table: "Orders",
                column: "BillingAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_BillingAddressId",
                table: "Orders",
                column: "BillingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_BillingAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_ShippingAddressId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BillingAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingAddressId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1be601ee-9054-4b5e-a233-bb0654f6f54f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2e1c51ca-3243-464d-9f16-f6b985e28a7d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("39c95e72-cf33-44be-a93e-b9b6097c4324"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("60671684-b470-4ec7-8496-b7290c3469cc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("69f7c992-b590-459d-8827-54dbe1493a87"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6d138d7c-d6c4-41e8-8ecb-3e66ebe7b52a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7caf6b66-4108-4d38-9492-0a71ed80d7c1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8e8d0322-5ce9-4178-91a1-e2c3aa6fd977"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9eb262cd-df1d-4377-9727-7e33e42ba6c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("beafb549-6a09-4fbd-8f27-9dbc44ec906c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d2a2510f-8b37-4d31-a3ed-a7b645a29751"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fe08feeb-c55a-4cd8-9130-e4ea1ee90a91"));

            migrationBuilder.DropColumn(
                name: "BillingAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAddressId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedOnUtc", "Category", "Description", "Price", "Quantity", "Sku", "Title" },
                values: new object[,]
                {
                    { new Guid("0f852a3c-68bb-4124-aa9e-95c83dc23a83"), new DateTime(2024, 8, 28, 14, 27, 19, 690, DateTimeKind.Utc).AddTicks(3085), 0, "A high-performance laptop powered by the M2 chip.", 1699.99, 5L, "MBP0004", "MacBook Pro M2" },
                    { new Guid("4df52493-9f22-42b0-a5ba-84b359403b5b"), new DateTime(2024, 8, 28, 14, 27, 19, 690, DateTimeKind.Utc).AddTicks(3082), 0, "A powerful Android smartphone with advanced features.", 1199.99, 5L, "SGS23U0002", "Samsung Galaxy S23 Ultra" },
                    { new Guid("56d0ccb5-de4a-4853-bdd6-0b2a2b351635"), new DateTime(2024, 8, 28, 14, 27, 19, 690, DateTimeKind.Utc).AddTicks(3070), 0, "The latest flagship smartphone from Apple.", 1299.99, 5L, "IPH14P0001", "iPhone 14 Pro" },
                    { new Guid("574ebadd-084e-4afd-808b-689e271026e7"), new DateTime(2024, 8, 28, 14, 27, 19, 690, DateTimeKind.Utc).AddTicks(3089), 0, "A high-quality OLED TV with stunning picture quality.", 1999.99, 5L, "LGTVC20008", "LG OLED TV C2 Series" },
                    { new Guid("6a1758ba-d604-4523-8b4a-f6c18030bde8"), new DateTime(2024, 8, 28, 14, 27, 19, 690, DateTimeKind.Utc).AddTicks(3068), 3, "This is a LED lamp which used for lightning", 50.0, 5L, "KOP1ESOSE3", "Lamp" },
                    { new Guid("8aa8572f-b6c6-43aa-8742-0224ef73b35f"), new DateTime(2024, 8, 28, 14, 27, 19, 690, DateTimeKind.Utc).AddTicks(3086), 0, "The latest gaming console from Sony.", 499.99000000000001, 5L, "PS50005", "PlayStation 5" },
                    { new Guid("8f38ff7c-58c8-4b6c-9bb0-45182a5c32cf"), new DateTime(2024, 8, 28, 14, 27, 19, 690, DateTimeKind.Utc).AddTicks(3093), 3, "A reliable dishwasher with efficient cleaning performance.", 799.99000000000001, 5L, "BOSH0010", "Bosch Dishwasher" },
                    { new Guid("9871859e-2ec9-40b9-9099-ff1cb1fb6276"), new DateTime(2024, 8, 28, 14, 27, 19, 690, DateTimeKind.Utc).AddTicks(3088), 0, "A hybrid console with a high-resolution OLED screen.", 349.99000000000001, 5L, "NSO0007", "Nintendo Switch OLED" },
                    { new Guid("a0aef1de-687e-441a-8a42-c02c9bd0f938"), new DateTime(2024, 8, 28, 14, 27, 19, 690, DateTimeKind.Utc).AddTicks(3090), 0, "A high-quality QLED TV with excellent picture quality.", 1799.99, 5L, "SAMQ90B0009", "Samsung QLED TV QN90B" },
                    { new Guid("c02cb303-0f6e-4736-8957-8d007d25e4f8"), new DateTime(2024, 8, 28, 14, 27, 19, 690, DateTimeKind.Utc).AddTicks(3061), 0, "This is a sony headphones description", 700.5, 5L, "S0K462HYLS", "Sony" },
                    { new Guid("c092a9d9-fac3-49b6-8fab-6b4bf90308d3"), new DateTime(2024, 8, 28, 14, 27, 19, 690, DateTimeKind.Utc).AddTicks(3084), 0, "A premium laptop with a sleek design and powerful performance.", 1499.99, 5L, "DXPS130003", "Dell XPS 13" },
                    { new Guid("e0267593-7492-4144-9557-75861cde7d98"), new DateTime(2024, 8, 28, 14, 27, 19, 690, DateTimeKind.Utc).AddTicks(3087), 0, "A powerful gaming console from Microsoft.", 499.99000000000001, 5L, "XSX0006", "Xbox Series X" }
                });
        }
    }
}
