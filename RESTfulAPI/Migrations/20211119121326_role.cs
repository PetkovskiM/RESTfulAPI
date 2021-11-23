using Microsoft.EntityFrameworkCore.Migrations;

namespace RESTfulAPI.Migrations
{
    public partial class role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e67c53c-84b1-458c-906f-bb7e69fc136d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efd5c6ed-61e1-4c04-9db7-9c9ca5e246d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d01d9221-0de1-45d2-b0cd-ea2acacebbfb", "d6de7270-b616-45ec-8740-d9d35bd26eae", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "60a832c0-91d7-4bb1-b2f7-bb9bd638f564", "eed7749e-330d-4460-bd9c-7d5426781d81", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60a832c0-91d7-4bb1-b2f7-bb9bd638f564");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d01d9221-0de1-45d2-b0cd-ea2acacebbfb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efd5c6ed-61e1-4c04-9db7-9c9ca5e246d4", "9d60867f-0e20-4509-8987-04fa0e110192", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e67c53c-84b1-458c-906f-bb7e69fc136d", "45670712-18b3-4118-bc31-32b473d248e9", "Administrator", "ADMINISTRATOR" });
        }
    }
}
