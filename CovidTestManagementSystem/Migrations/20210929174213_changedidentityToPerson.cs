using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidTestManagementSystem.Migrations
{
    public partial class changedidentityToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRecords_Nurses_NurseId",
                table: "TestRecords");

            migrationBuilder.DropIndex(
                name: "IX_TestRecords_NurseId",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "NurseId",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "NursesId",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "TestRecords");

            migrationBuilder.AlterColumn<bool>(
                name: "FinalReportStatus",
                table: "TestRecords",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TestAppointmentVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentTime = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<string>(nullable: true),
                    NurseId = table.Column<int>(nullable: true),
                    TestTypeId = table.Column<int>(nullable: true),
                    TestRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAppointmentVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestAppointmentVM_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestAppointmentVM_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestAppointmentVM_TestRecords_TestRecordId",
                        column: x => x.TestRecordId,
                        principalTable: "TestRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestAppointmentVM_TestTypes_TestTypeId",
                        column: x => x.TestTypeId,
                        principalTable: "TestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestRecordVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportStatus = table.Column<bool>(nullable: true),
                    TestTypeId = table.Column<int>(nullable: false),
                    TestTimeslot = table.Column<DateTime>(nullable: false),
                    NursesId = table.Column<int>(nullable: false),
                    FinalReportStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRecordVM", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestAppointmentVM_NurseId",
                table: "TestAppointmentVM",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAppointmentVM_PatientId",
                table: "TestAppointmentVM",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAppointmentVM_TestRecordId",
                table: "TestAppointmentVM",
                column: "TestRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAppointmentVM_TestTypeId",
                table: "TestAppointmentVM",
                column: "TestTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestAppointmentVM");

            migrationBuilder.DropTable(
                name: "TestRecordVM");

            migrationBuilder.AlterColumn<string>(
                name: "FinalReportStatus",
                table: "TestRecords",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "NurseId",
                table: "TestRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NursesId",
                table: "TestRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReportStatus",
                table: "TestRecords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_NurseId",
                table: "TestRecords",
                column: "NurseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestRecords_Nurses_NurseId",
                table: "TestRecords",
                column: "NurseId",
                principalTable: "Nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
