using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Persistence.Infrastructure.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("52b24128-6129-4cb1-aeb4-1cd0c2ef5f54"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("b2bf9c0e-101c-4da5-8fe4-92a0ba2c1209"));

            migrationBuilder.InsertData(
                table: "CriticalValues",
                columns: new[] { "Id", "Value", "ValueName" },
                values: new object[,]
                {
                    { new Guid("1a0ba29a-83ef-4d6c-8cb1-fb28150bd584"), 0.0, "MinimalWindSpeed" },
                    { new Guid("3c0a51a2-dd03-4ed9-8bbc-eea553214235"), 10.0, "MaximalWindSpeed" },
                    { new Guid("a9d38d73-53ab-407b-93ed-8ab04ab11867"), 1000.0, "MinimalPressure" },
                    { new Guid("d667d696-d52a-47c8-9b66-2178ce291c6a"), 1100.0, "MaximalPressure" },
                    { new Guid("0e44f9e1-666d-4a16-8906-ec9979a2a37f"), 30.0, "MinimalHumidity" },
                    { new Guid("84f5660f-6616-405d-b3a6-f269a18f6692"), 100.0, "MaximalHumidity" },
                    { new Guid("b88eb944-fe18-4ad6-bb68-f61665094c36"), 278.0, "MinimalTemperature" },
                    { new Guid("5c3e4881-16d2-4a88-bcd1-a9a3af7c4798"), 288.0, "MaximalTemperature" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("0e44f9e1-666d-4a16-8906-ec9979a2a37f"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("1a0ba29a-83ef-4d6c-8cb1-fb28150bd584"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("3c0a51a2-dd03-4ed9-8bbc-eea553214235"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("5c3e4881-16d2-4a88-bcd1-a9a3af7c4798"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("84f5660f-6616-405d-b3a6-f269a18f6692"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("a9d38d73-53ab-407b-93ed-8ab04ab11867"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("b88eb944-fe18-4ad6-bb68-f61665094c36"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("d667d696-d52a-47c8-9b66-2178ce291c6a"));

            migrationBuilder.InsertData(
                table: "CriticalValues",
                columns: new[] { "Id", "Value", "ValueName" },
                values: new object[] { new Guid("b2bf9c0e-101c-4da5-8fe4-92a0ba2c1209"), 278.0, "MinimalTemperature" });

            migrationBuilder.InsertData(
                table: "CriticalValues",
                columns: new[] { "Id", "Value", "ValueName" },
                values: new object[] { new Guid("52b24128-6129-4cb1-aeb4-1cd0c2ef5f54"), 288.0, "MaximalTemperature" });
        }
    }
}
