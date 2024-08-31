using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProfileImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Users",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ProfileImageUrl",
                table: "Users");

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
        }
    }
}
