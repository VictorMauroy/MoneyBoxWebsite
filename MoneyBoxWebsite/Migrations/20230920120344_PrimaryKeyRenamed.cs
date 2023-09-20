using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyBoxWebsite.Migrations
{
    /// <inheritdoc />
    public partial class PrimaryKeyRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Orders_LinkedOrderId",
                table: "ProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Products_LinkedProductId",
                table: "ProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductGroup_ProductGroups_ProductGroupsId",
                table: "ProductProductGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductGroup_Products_GroupedProductsId",
                table: "ProductProductGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_LinkedProductId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "LinkedProductId",
                table: "Reviews",
                newName: "LinkedProductProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_LinkedProductId",
                table: "Reviews",
                newName: "IX_Reviews_LinkedProductProductId");

            migrationBuilder.RenameColumn(
                name: "ProductGroupsId",
                table: "ProductProductGroup",
                newName: "ProductGroupsProductGroupId");

            migrationBuilder.RenameColumn(
                name: "GroupedProductsId",
                table: "ProductProductGroup",
                newName: "GroupedProductsProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProductGroup_ProductGroupsId",
                table: "ProductProductGroup",
                newName: "IX_ProductProductGroup_ProductGroupsProductGroupId");

            migrationBuilder.RenameColumn(
                name: "LinkedProductId",
                table: "ProductOrder",
                newName: "LinkedProductProductId");

            migrationBuilder.RenameColumn(
                name: "LinkedOrderId",
                table: "ProductOrder",
                newName: "LinkedOrderOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrder_LinkedProductId",
                table: "ProductOrder",
                newName: "IX_ProductOrder_LinkedProductProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrder_LinkedOrderId",
                table: "ProductOrder",
                newName: "IX_ProductOrder_LinkedOrderOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Orders_LinkedOrderOrderId",
                table: "ProductOrder",
                column: "LinkedOrderOrderId",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Products_LinkedProductProductId",
                table: "ProductOrder",
                column: "LinkedProductProductId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductGroup_ProductGroups_ProductGroupsProductGroupId",
                table: "ProductProductGroup",
                column: "ProductGroupsProductGroupId",
                principalTable: "ProductGroups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductGroup_Products_GroupedProductsProductId",
                table: "ProductProductGroup",
                column: "GroupedProductsProductId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_LinkedProductProductId",
                table: "Reviews",
                column: "LinkedProductProductId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Orders_LinkedOrderOrderId",
                table: "ProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Products_LinkedProductProductId",
                table: "ProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductGroup_ProductGroups_ProductGroupsProductGroupId",
                table: "ProductProductGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductGroup_Products_GroupedProductsProductId",
                table: "ProductProductGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_LinkedProductProductId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "LinkedProductProductId",
                table: "Reviews",
                newName: "LinkedProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_LinkedProductProductId",
                table: "Reviews",
                newName: "IX_Reviews_LinkedProductId");

            migrationBuilder.RenameColumn(
                name: "ProductGroupsProductGroupId",
                table: "ProductProductGroup",
                newName: "ProductGroupsId");

            migrationBuilder.RenameColumn(
                name: "GroupedProductsProductId",
                table: "ProductProductGroup",
                newName: "GroupedProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProductGroup_ProductGroupsProductGroupId",
                table: "ProductProductGroup",
                newName: "IX_ProductProductGroup_ProductGroupsId");

            migrationBuilder.RenameColumn(
                name: "LinkedProductProductId",
                table: "ProductOrder",
                newName: "LinkedProductId");

            migrationBuilder.RenameColumn(
                name: "LinkedOrderOrderId",
                table: "ProductOrder",
                newName: "LinkedOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrder_LinkedProductProductId",
                table: "ProductOrder",
                newName: "IX_ProductOrder_LinkedProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrder_LinkedOrderOrderId",
                table: "ProductOrder",
                newName: "IX_ProductOrder_LinkedOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Orders_LinkedOrderId",
                table: "ProductOrder",
                column: "LinkedOrderId",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Products_LinkedProductId",
                table: "ProductOrder",
                column: "LinkedProductId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductGroup_ProductGroups_ProductGroupsId",
                table: "ProductProductGroup",
                column: "ProductGroupsId",
                principalTable: "ProductGroups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductGroup_Products_GroupedProductsId",
                table: "ProductProductGroup",
                column: "GroupedProductsId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_LinkedProductId",
                table: "Reviews",
                column: "LinkedProductId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
