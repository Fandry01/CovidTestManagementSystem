using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidTestManagementSystem.Data.Migrations
{
    public partial class ChangedTestTypeClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Antigen",
                table: "TestTypes");

            migrationBuilder.DropColumn(
                name: "BreathTest",
                table: "TestTypes");

            migrationBuilder.DropColumn(
                name: "Lamp",
                table: "TestTypes");

            migrationBuilder.DropColumn(
                name: "PCR",
                table: "TestTypes");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "TestTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TestTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "TestTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TestTypes");

            migrationBuilder.AddColumn<string>(
                name: "Antigen",
                table: "TestTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BreathTest",
                table: "TestTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lamp",
                table: "TestTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PCR",
                table: "TestTypes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
