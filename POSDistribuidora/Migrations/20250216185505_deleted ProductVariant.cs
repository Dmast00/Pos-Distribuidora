using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSDistribuidora.Migrations
{
    public partial class deletedProductVariant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetail_ProductVariant_ProductVariantId",
                table: "SaleDetail");

            migrationBuilder.DropIndex(
                name: "IX_SaleDetail_ProductVariantId",
                table: "SaleDetail");

            migrationBuilder.DropColumn(
                name: "ProductVariantId",
                table: "SaleDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductVariantId",
                table: "SaleDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_ProductVariantId",
                table: "SaleDetail",
                column: "ProductVariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetail_ProductVariant_ProductVariantId",
                table: "SaleDetail",
                column: "ProductVariantId",
                principalTable: "ProductVariant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
