using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class Adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999997,
                column: "ConcurrencyStamp",
                value: "24bf7da1-1c1b-4f32-bb86-3a15a58cbb33");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "b6409217-bd35-49f5-ba79-494f6125b13d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c39edb6f-ddb4-4276-9d16-5f86bf524e5f", "AQAAAAEAACcQAAAAEBRCwbqD/m5lQUBh5bN42S2J2lAgZ5COujvJg+IqINlriADtLa5dSrRz3aReIk6NMQ==", "85cbb272-c5f2-4a2d-abc0-d66866d0ce29" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999997,
                column: "ConcurrencyStamp",
                value: "2b02bece-4633-4a89-a827-17e443f44ebc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "c5555512-bec7-405b-8e73-212a019803db");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4a0434f-0375-4d2f-bbf1-0dcfd92e1cf1", "AQAAAAEAACcQAAAAEGQuaH9uEIwTN2cU7f6zQZiNJ8JSZF6wKRVnXGC3YdJxBnYlBvJVfTNVeGmvcHuPaw==", "d578fc71-a1b6-461f-a53c-94b9812b7726" });
        }
    }
}
