using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GizaTraffic.DBContext.Migrations
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramSettings",
                columns: table => new
                {
                    ProgramSettingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrinterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QRCodeHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QRCodeFooter = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramSettings", x => x.ProgramSettingID);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesImpounds",
                columns: table => new
                {
                    VehicleImpoundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleChassisNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleEngineNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseReportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseReportType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerNationalIDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverNationalIDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleImpoundNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImpoundDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesImpounds", x => x.VehicleImpoundId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramSettings");

            migrationBuilder.DropTable(
                name: "VehiclesImpounds");
        }
    }
}
