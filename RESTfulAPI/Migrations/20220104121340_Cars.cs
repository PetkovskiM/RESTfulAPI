using Microsoft.EntityFrameworkCore.Migrations;

namespace RESTfulAPI.Migrations
{
    public partial class Cars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60a832c0-91d7-4bb1-b2f7-bb9bd638f564");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d01d9221-0de1-45d2-b0cd-ea2acacebbfb");

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Car = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MPG = table.Column<float>(type: "real", nullable: false),
                    Cylinders = table.Column<int>(type: "int", nullable: false),
                    Displacement = table.Column<int>(type: "int", nullable: false),
                    Horsepower = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acceleration = table.Column<double>(type: "float", nullable: false),
                    Model = table.Column<int>(type: "int", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ca5c534-448d-4ca3-a37c-8450f8261b27", "2aed3959-4700-4e55-8dd2-ac2f4406a376", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "643767fa-d024-460f-be6a-4c356aabbbae", "a38c2ecb-fd0c-4157-a153-90b228f5480f", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "643767fa-d024-460f-be6a-4c356aabbbae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ca5c534-448d-4ca3-a37c-8450f8261b27");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d01d9221-0de1-45d2-b0cd-ea2acacebbfb", "d6de7270-b616-45ec-8740-d9d35bd26eae", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "60a832c0-91d7-4bb1-b2f7-bb9bd638f564", "eed7749e-330d-4460-bd9c-7d5426781d81", "Administrator", "ADMINISTRATOR" });
        }
    }
}
