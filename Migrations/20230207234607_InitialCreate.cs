using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrucksAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tare = table.Column<int>(type: "int", nullable: false),
                    LoadCapacity = table.Column<int>(type: "int", nullable: false),
                    MaximumBatteryCharge = table.Column<int>(type: "int", nullable: false),
                    AutonomyWhenFullyCharged = table.Column<int>(type: "int", nullable: false),
                    FastChargingTime = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trucks");
        }
    }
}
