using Microsoft.EntityFrameworkCore.Migrations;

namespace RESTfulAPI.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efd5c6ed-61e1-4c04-9db7-9c9ca5e246d4", "9d60867f-0e20-4509-8987-04fa0e110192", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e67c53c-84b1-458c-906f-bb7e69fc136d", "45670712-18b3-4118-bc31-32b473d248e9", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e67c53c-84b1-458c-906f-bb7e69fc136d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efd5c6ed-61e1-4c04-9db7-9c9ca5e246d4");
        }
    }
}
