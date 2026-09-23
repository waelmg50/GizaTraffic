using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GizaTraffic.DBContext.Migrations
{
    /// <inheritdoc />
    public partial class Add_VehicleSector : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VehicleSector",
                table: "VehiclesImpounds",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleSector",
                table: "VehiclesImpounds");
        }
    }
}
