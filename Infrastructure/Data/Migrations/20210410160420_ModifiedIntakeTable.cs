using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class ModifiedIntakeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Energy",
                table: "Intakes",
                newName: "EnergyKJ");

            migrationBuilder.AddColumn<double>(
                name: "Carbohydrates",
                table: "Intakes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "EnergyKCAL",
                table: "Intakes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Fibres",
                table: "Intakes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Proteins",
                table: "Intakes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carbohydrates",
                table: "Intakes");

            migrationBuilder.DropColumn(
                name: "EnergyKCAL",
                table: "Intakes");

            migrationBuilder.DropColumn(
                name: "Fibres",
                table: "Intakes");

            migrationBuilder.DropColumn(
                name: "Proteins",
                table: "Intakes");

            migrationBuilder.RenameColumn(
                name: "EnergyKJ",
                table: "Intakes",
                newName: "Energy");
        }
    }
}
