using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class DietChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_Recipes_RecipeId",
                table: "Diets");

            migrationBuilder.DropIndex(
                name: "IX_Diets_RecipeId",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Diets");

            migrationBuilder.AddColumn<int>(
                name: "DietId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_DietId",
                table: "Recipes",
                column: "DietId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Diets_DietId",
                table: "Recipes",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Diets_DietId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_DietId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "DietId",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Diets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diets_RecipeId",
                table: "Diets",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_Recipes_RecipeId",
                table: "Diets",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
