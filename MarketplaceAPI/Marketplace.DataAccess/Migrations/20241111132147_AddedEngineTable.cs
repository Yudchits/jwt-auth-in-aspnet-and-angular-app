using Microsoft.EntityFrameworkCore.Migrations;

namespace Marketplace.DataAccess.Migrations
{
    public partial class AddedEngineTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Transmission",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "EngineId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Capacity = table.Column<double>(type: "float", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineId",
                table: "Cars",
                column: "EngineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Engines_EngineId",
                table: "Cars",
                column: "EngineId",
                principalTable: "Engines",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Engines_EngineId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropIndex(
                name: "IX_Cars_EngineId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EngineId",
                table: "Cars");

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
                name: "Transmission",
                table: "Cars",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }
    }
}
