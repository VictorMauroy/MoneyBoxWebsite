using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoneyBoxWebsite.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4654e771-5273-4a55-b252-3eb3b64d5635");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "638d32e0-196a-40bb-afbf-1dce3067e816");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "680cb93c-40b6-40fe-bf60-eaa30a69c993");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8331d68b-59a0-4b67-96d2-998fb87e57bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca072754-dc4b-46aa-ac84-2f6a9e120d79");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06e6abbb-e293-4e2f-bae5-f4e2d09c9d95", null, "Client", null },
                    { "0b40c1a7-6392-4f09-8d80-7fbbf1914877", null, "Manager", null },
                    { "0e240aac-2f35-4eaf-8f08-2b0827dfa9f1", null, "Moderator", null },
                    { "2e3b1ee8-eeef-4285-af50-37b289d7e0d1", null, "Assistant", null },
                    { "871e243c-4f9d-408f-a887-d323ce449cde", null, "Administrator", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "color", "description", "height", "image_file_path", "length", "manufacturer", "money_capacity", "name", "price", "reference", "visibility", "weight", "width" },
                values: new object[,]
                {
                    { new Guid("48e3dc43-0292-4af5-ae68-1e45d8000123"), "Pink", "You all have it in mind and now it's on sale!", 15f, "/images/0001.jpg", 15f, "Database", 56, "Classic Pink", 50f, "#000001", true, 1f, 20f },
                    { new Guid("ca1a9fb3-4d3e-4c5c-8663-ee537d61d4b4"), "Red", "Should be red but we didn't have any red colorant in our stock.", 15f, "/images/0003.jpg", 15f, "Database", 51, "Red pink", 25f, "#000003", true, 1.5f, 20f },
                    { new Guid("ce3b2d92-f3c8-47cb-a84a-4da188b981c7"), "Pink", "There will never be enough of pink in your life.", 10f, "/images/0002.jpg", 15f, "Database", 42, "Pink pink", 65f, "#000002", true, 0.7f, 15f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06e6abbb-e293-4e2f-bae5-f4e2d09c9d95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b40c1a7-6392-4f09-8d80-7fbbf1914877");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e240aac-2f35-4eaf-8f08-2b0827dfa9f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e3b1ee8-eeef-4285-af50-37b289d7e0d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "871e243c-4f9d-408f-a887-d323ce449cde");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: new Guid("48e3dc43-0292-4af5-ae68-1e45d8000123"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: new Guid("ca1a9fb3-4d3e-4c5c-8663-ee537d61d4b4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: new Guid("ce3b2d92-f3c8-47cb-a84a-4da188b981c7"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4654e771-5273-4a55-b252-3eb3b64d5635", null, "Administrator", null },
                    { "638d32e0-196a-40bb-afbf-1dce3067e816", null, "Client", null },
                    { "680cb93c-40b6-40fe-bf60-eaa30a69c993", null, "Moderator", null },
                    { "8331d68b-59a0-4b67-96d2-998fb87e57bb", null, "Assistant", null },
                    { "ca072754-dc4b-46aa-ac84-2f6a9e120d79", null, "Manager", null }
                });
        }
    }
}
