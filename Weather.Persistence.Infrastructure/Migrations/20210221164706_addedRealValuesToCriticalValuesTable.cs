using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Persistence.Infrastructure.Migrations
{
    public partial class addedRealValuesToCriticalValuesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { new Guid("b74322db-e363-4827-9812-8032d866cb7f"), 0.0, "MinimalWindSpeed" },
                    { new Guid("93b28cdd-0354-419e-b3e7-360eaa8d9ac8"), 10.0, "MaximalWindSpeed" },
                    { new Guid("fd966929-c95a-478b-8e9e-ab043c720bd9"), 1000.0, "MinimalPressure" },
                    { new Guid("6229a34a-74a6-4aaa-9ece-486a55a0330b"), 1100.0, "MaximalPressure" },
                    { new Guid("c386ebb5-fa6a-4953-8f4b-d2a1c2b82e1e"), 30.0, "MinimalHumidity" },
                    { new Guid("fec82ea5-d7f5-47e9-b5cf-dcfa9f956ee7"), 100.0, "MaximalHumidity" },
                    { new Guid("fe4aad14-1a5c-48be-8be3-8eb14b051190"), 278.0, "MinimalTemperature" },
                    { new Guid("21f8314b-f37f-4c73-9bcb-52b0e7aea45a"), 288.0, "MaximalTemperature" },
                    { new Guid("7058de6b-b2e9-4de5-b919-400dd87fe38e"), 0.0, "MinimalRealWindSpeed" },
                    { new Guid("212a0295-ad9e-42c7-9fda-24aec2e69527"), 10.0, "MaximalRealWindSpeed" },
                    { new Guid("69179feb-761e-4439-a741-4b37213e21d0"), 1000.0, "MinimalRealPressure" },
                    { new Guid("54554279-9152-4a5a-9b31-a90660401a57"), 1100.0, "MaximalRealPressure" },
                    { new Guid("38b1c9f0-f7f8-46e6-aa06-65ef42605852"), 30.0, "MinimalRealHumidity" },
                    { new Guid("ba5773d5-b34e-407b-8eb1-b59aabbe0a6e"), 100.0, "MaximalRealHumidity" },
                    { new Guid("a2bee0a1-a808-46cd-9854-79e8bd9d5c58"), 278.0, "MinimalRealTemperature" },
                    { new Guid("4034b082-eb68-4857-a2fb-9c042611f238"), 288.0, "MaximalRealTemperature" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("212a0295-ad9e-42c7-9fda-24aec2e69527"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("21f8314b-f37f-4c73-9bcb-52b0e7aea45a"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("38b1c9f0-f7f8-46e6-aa06-65ef42605852"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("4034b082-eb68-4857-a2fb-9c042611f238"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("54554279-9152-4a5a-9b31-a90660401a57"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("6229a34a-74a6-4aaa-9ece-486a55a0330b"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("69179feb-761e-4439-a741-4b37213e21d0"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("7058de6b-b2e9-4de5-b919-400dd87fe38e"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("93b28cdd-0354-419e-b3e7-360eaa8d9ac8"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("a2bee0a1-a808-46cd-9854-79e8bd9d5c58"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("b74322db-e363-4827-9812-8032d866cb7f"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("ba5773d5-b34e-407b-8eb1-b59aabbe0a6e"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("c386ebb5-fa6a-4953-8f4b-d2a1c2b82e1e"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("fd966929-c95a-478b-8e9e-ab043c720bd9"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("fe4aad14-1a5c-48be-8be3-8eb14b051190"));

            migrationBuilder.DeleteData(
                table: "CriticalValues",
                keyColumn: "Id",
                keyValue: new Guid("fec82ea5-d7f5-47e9-b5cf-dcfa9f956ee7"));

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
    }
}
