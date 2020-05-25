using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Persistence.Infrastructure.Migrations
{
    public partial class addedCriticalValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CriticalValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    ValueName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriticalValues", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CriticalValues",
                columns: new[] { "Id", "Value", "ValueName" },
                values: new object[] { new Guid("b2bf9c0e-101c-4da5-8fe4-92a0ba2c1209"), 278.0, "MinimalTemperature" });

            migrationBuilder.InsertData(
                table: "CriticalValues",
                columns: new[] { "Id", "Value", "ValueName" },
                values: new object[] { new Guid("52b24128-6129-4cb1-aeb4-1cd0c2ef5f54"), 288.0, "MaximalTemperature" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CriticalValues");

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
    }
}
