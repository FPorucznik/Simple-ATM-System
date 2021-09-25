using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleATMSystem.Migrations
{
    public partial class initalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    PinHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance", "DateOfBirth", "FirstName", "LastName", "PinHash" },
                values: new object[] { 1, 123456789, 2340m, new DateTime(1990, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Smith", "ciSYdF0TrB96wOl27yYEcA==fXF2p7e34GRipBh1ptxvKwNEcMdgp/IC0wbOG+RVBhw=" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance", "DateOfBirth", "FirstName", "LastName", "PinHash" },
                values: new object[] { 2, 111111111, 3120m, new DateTime(1993, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mary", "Green", "rbScURTPhTZ65H35ejN5BA==J5cNESF22JVk7jj1wP+gR32C4cIXUnaOMFVzVEjN5M8=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
