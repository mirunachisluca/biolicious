using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class RecipeIntake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IntakeId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_IntakeId",
                table: "Recipes",
                column: "IntakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Intakes_IntakeId",
                table: "Recipes",
                column: "IntakeId",
                principalTable: "Intakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Intakes_IntakeId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_IntakeId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IntakeId",
                table: "Recipes");
        }
    }
}
