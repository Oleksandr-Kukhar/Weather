using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Persistence.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Humidity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    RegisterTime = table.Column<DateTime>(nullable: false),
                    MeasurementUnits = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humidity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pressure",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    RegisterTime = table.Column<DateTime>(nullable: false),
                    MeasurementUnits = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pressure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    RegisterTime = table.Column<DateTime>(nullable: false),
                    MeasurementUnits = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wind",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Speed = table.Column<double>(nullable: false),
                    Direction = table.Column<int>(nullable: false),
                    RegisterTime = table.Column<DateTime>(nullable: false),
                    MeasurementUnits = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wind", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Humidity",
                columns: new[] { "Id", "MeasurementUnits", "RegisterTime", "Value" },
                values: new object[] { new Guid("993f8938-7824-43a0-9781-a8caca08be80"), "%", new DateTime(2020, 5, 22, 16, 50, 27, 261, DateTimeKind.Local).AddTicks(7885), 50.0 });

            migrationBuilder.InsertData(
                table: "Pressure",
                columns: new[] { "Id", "MeasurementUnits", "RegisterTime", "Value" },
                values: new object[] { new Guid("80efcaf4-b31f-4dcd-84c9-c430df59e382"), "hPa", new DateTime(2020, 5, 22, 16, 50, 27, 261, DateTimeKind.Local).AddTicks(5165), 1010.0 });

            migrationBuilder.InsertData(
                table: "Temperature",
                columns: new[] { "Id", "MeasurementUnits", "RegisterTime", "Value" },
                values: new object[] { new Guid("592ffb90-56e9-4dd6-8c07-b78c718b7d17"), "Kelvin", new DateTime(2020, 5, 22, 16, 50, 27, 258, DateTimeKind.Local).AddTicks(58), 14.0 });

            migrationBuilder.InsertData(
                table: "Wind",
                columns: new[] { "Id", "Direction", "MeasurementUnits", "RegisterTime", "Speed" },
                values: new object[] { new Guid("eeed3ce2-cd98-4de9-b685-5b292f9584c6"), 0, "m/s", new DateTime(2020, 5, 22, 16, 50, 27, 262, DateTimeKind.Local).AddTicks(811), 5.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Humidity");

            migrationBuilder.DropTable(
                name: "Pressure");

            migrationBuilder.DropTable(
                name: "Temperature");

            migrationBuilder.DropTable(
                name: "Wind");
        }
    }
}
