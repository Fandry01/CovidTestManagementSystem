using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidTestManagementSystem.Migrations
{
    public partial class ChangedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRecords_TestAppointments_TestAppointmentId",
                table: "TestRecords");

            migrationBuilder.DropTable(
                name: "TestAppointmentVM");

            migrationBuilder.DropTable(
                name: "TestRecordVM");

            migrationBuilder.DropIndex(
                name: "IX_TestRecords_TestAppointmentId",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "TestAppointmentId",
                table: "TestRecords");

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_AppointmentId",
                table: "TestRecords",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestRecords_TestAppointments_AppointmentId",
                table: "TestRecords",
                column: "AppointmentId",
                principalTable: "TestAppointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRecords_TestAppointments_AppointmentId",
                table: "TestRecords");

            migrationBuilder.DropIndex(
                name: "IX_TestRecords_AppointmentId",
                table: "TestRecords");

            migrationBuilder.AddColumn<int>(
                name: "TestAppointmentId",
                table: "TestRecords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TestAppointmentVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NurseId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TestRecordId = table.Column<int>(type: "int", nullable: true),
                    TestTypeId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinalReportStatus = table.Column<bool>(type: "bit", nullable: false),
                    NursesId = table.Column<int>(type: "int", nullable: false),
                    ReportStatus = table.Column<bool>(type: "bit", nullable: true),
                    TestAppointmentId = table.Column<int>(type: "int", nullable: true),
                    TestTimeslot = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRecordVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestRecordVM_TestAppointments_TestAppointmentId",
                        column: x => x.TestAppointmentId,
                        principalTable: "TestAppointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_TestAppointmentId",
                table: "TestRecords",
                column: "TestAppointmentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TestRecordVM_TestAppointmentId",
                table: "TestRecordVM",
                column: "TestAppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestRecords_TestAppointments_TestAppointmentId",
                table: "TestRecords",
                column: "TestAppointmentId",
                principalTable: "TestAppointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
