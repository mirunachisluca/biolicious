using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class ChangedCategoryColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSubcategories_ProductCategories_ProductTypeId",
                table: "ProductSubcategories");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "ProductSubcategories",
                newName: "ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSubcategories_ProductTypeId",
                table: "ProductSubcategories",
                newName: "IX_ProductSubcategories_ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSubcategories_ProductCategories_ProductCategoryId",
                table: "ProductSubcategories",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSubcategories_ProductCategories_ProductCategoryId",
                table: "ProductSubcategories");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "ProductSubcategories",
                newName: "ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSubcategories_ProductCategoryId",
                table: "ProductSubcategories",
                newName: "IX_ProductSubcategories_ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSubcategories_ProductCategories_ProductTypeId",
                table: "ProductSubcategories",
                column: "ProductTypeId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
