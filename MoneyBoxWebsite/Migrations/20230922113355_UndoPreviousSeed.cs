using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoneyBoxWebsite.Migrations
{
    /// <inheritdoc />
    public partial class UndoPreviousSeed : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
