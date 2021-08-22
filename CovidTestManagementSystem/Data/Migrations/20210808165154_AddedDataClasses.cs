using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidTestManagementSystem.Data.Migrations
{
    public partial class AddedDataClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateofBirth",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddres",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sofinummer",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telnummer",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Employeeid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PCR = table.Column<string>(nullable: true),
                    Lamp = table.Column<string>(nullable: true),
                    Antigen = table.Column<string>(nullable: true),
                    BreathTest = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(nullable: true),
                    ReportStatus = table.Column<string>(nullable: true),
                    TestTypeId = table.Column<int>(nullable: false),
                    TestTimeslot = table.Column<DateTime>(nullable: false),
                    NurseId = table.Column<int>(nullable: true),
                    NursesId = table.Column<int>(nullable: false),
                    FinalReportStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestRecords_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestRecords_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestRecords_TestTypes_TestTypeId",
                        column: x => x.TestTypeId,
                        principalTable: "TestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_NurseId",
                table: "TestRecords",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_PatientId",
                table: "TestRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_TestTypeId",
                table: "TestRecords",
                column: "TestTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestRecords");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "TestTypes");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateofBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailAddres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sofinummer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telnummer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
