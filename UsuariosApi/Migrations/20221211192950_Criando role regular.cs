using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class Criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "c5555512-bec7-405b-8e73-212a019803db");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 999997, "2b02bece-4633-4a89-a827-17e443f44ebc", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4a0434f-0375-4d2f-bbf1-0dcfd92e1cf1", "AQAAAAEAACcQAAAAEGQuaH9uEIwTN2cU7f6zQZiNJ8JSZF6wKRVnXGC3YdJxBnYlBvJVfTNVeGmvcHuPaw==", "d578fc71-a1b6-461f-a53c-94b9812b7726" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "eb2fd364-85fa-4a4c-a905-b07184ac20e9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42ed3d07-b3e6-422a-89ba-983847b46974", "AQAAAAEAACcQAAAAEEwHjglLZ7B7V1Plhr59qNqWbg+pkmoeERb4QKCw2aIFEjNJm6rdYUnOPeqFlY6/dA==", "f2e56de0-21e7-4a8d-936e-c9c9f9fde1f9" });
        }
    }
}
