using Microsoft.EntityFrameworkCore.Migrations;

namespace Marketplace.DataAccess.Migrations
{
    public partial class AddedSomePropsToCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DriveSystem",
                table: "Cars",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "EngineCapacity",
                table: "Cars",
                type: "decimal(3,1)",
                precision: 3,
                scale: 1,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "EnginePower",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Cars",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Generation",
                table: "Cars",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Transmission",
                table: "Cars",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Cars",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriveSystem",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EngineCapacity",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EnginePower",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Generation",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Cars");
        }
    }
}
