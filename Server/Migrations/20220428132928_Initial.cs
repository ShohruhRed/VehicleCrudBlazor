using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudBlazor.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "SPG" });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Heavy tank" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "VehicleCountry", "VehicleLevel", "VehicleModel", "VehicleTypeId" },
                values: new object[] { 1, "Great Britain", "10", "T95/FV4201 Chieftain", 1 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "VehicleCountry", "VehicleLevel", "VehicleModel", "VehicleTypeId" },
                values: new object[] { 2, "Japan", "10", "Type 5 Heavy", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
