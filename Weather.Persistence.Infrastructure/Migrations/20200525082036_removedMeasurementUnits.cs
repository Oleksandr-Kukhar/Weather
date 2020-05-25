using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Persistence.Infrastructure.Migrations
{
    public partial class removedMeasurementUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Humidity",
                keyColumn: "Id",
                keyValue: new Guid("993f8938-7824-43a0-9781-a8caca08be80"));

            migrationBuilder.DeleteData(
                table: "Pressure",
                keyColumn: "Id",
                keyValue: new Guid("80efcaf4-b31f-4dcd-84c9-c430df59e382"));

            migrationBuilder.DeleteData(
                table: "Temperature",
                keyColumn: "Id",
                keyValue: new Guid("592ffb90-56e9-4dd6-8c07-b78c718b7d17"));

            migrationBuilder.DeleteData(
                table: "Wind",
                keyColumn: "Id",
                keyValue: new Guid("eeed3ce2-cd98-4de9-b685-5b292f9584c6"));

            migrationBuilder.DropColumn(
                name: "MeasurementUnits",
                table: "Wind");

            migrationBuilder.DropColumn(
                name: "MeasurementUnits",
                table: "Temperature");

            migrationBuilder.DropColumn(
                name: "MeasurementUnits",
                table: "Pressure");

            migrationBuilder.DropColumn(
                name: "MeasurementUnits",
                table: "Humidity");

            migrationBuilder.InsertData(
                table: "Humidity",
                columns: new[] { "Id", "RegisterTime", "Value" },
                values: new object[] { new Guid("bf110ad6-c158-47f3-b5b2-c1cb5cd02c21"), new DateTime(2020, 5, 25, 11, 20, 35, 875, DateTimeKind.Local).AddTicks(7070), 50.0 });

            migrationBuilder.InsertData(
                table: "Pressure",
                columns: new[] { "Id", "RegisterTime", "Value" },
                values: new object[] { new Guid("fe753342-7427-4b80-baa6-48da3a2c2350"), new DateTime(2020, 5, 25, 11, 20, 35, 875, DateTimeKind.Local).AddTicks(4944), 1010.0 });

            migrationBuilder.InsertData(
                table: "Temperature",
                columns: new[] { "Id", "RegisterTime", "Value" },
                values: new object[] { new Guid("a8c8e1cb-e3e2-48b9-801c-d9b905c6210d"), new DateTime(2020, 5, 25, 11, 20, 35, 872, DateTimeKind.Local).AddTicks(2685), 14.0 });

            migrationBuilder.InsertData(
                table: "Wind",
                columns: new[] { "Id", "Direction", "RegisterTime", "Speed" },
                values: new object[] { new Guid("090898fb-c6ad-4527-871c-26c1d0d7c963"), 0, new DateTime(2020, 5, 25, 11, 20, 35, 875, DateTimeKind.Local).AddTicks(9874), 5.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Humidity",
                keyColumn: "Id",
                keyValue: new Guid("bf110ad6-c158-47f3-b5b2-c1cb5cd02c21"));

            migrationBuilder.DeleteData(
                table: "Pressure",
                keyColumn: "Id",
                keyValue: new Guid("fe753342-7427-4b80-baa6-48da3a2c2350"));

            migrationBuilder.DeleteData(
                table: "Temperature",
                keyColumn: "Id",
                keyValue: new Guid("a8c8e1cb-e3e2-48b9-801c-d9b905c6210d"));

            migrationBuilder.DeleteData(
                table: "Wind",
                keyColumn: "Id",
                keyValue: new Guid("090898fb-c6ad-4527-871c-26c1d0d7c963"));

            migrationBuilder.AddColumn<string>(
                name: "MeasurementUnits",
                table: "Wind",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeasurementUnits",
                table: "Temperature",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeasurementUnits",
                table: "Pressure",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeasurementUnits",
                table: "Humidity",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
