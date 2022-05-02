using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidTestManagementSystem.Migrations
{
    public partial class AddNewModelBuilder1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAppointments_TestTypes_TestTypeId",
                table: "TestAppointments");

            migrationBuilder.DropTable(
                name: "DetailsTestRecordVM");

            migrationBuilder.DropTable(
                name: "TestAppointmentVM");

            migrationBuilder.DropIndex(
                name: "IX_TestAppointments_TestRecordId",
                table: "TestAppointments");

            migrationBuilder.AddColumn<int>(
                name: "TestRecordId2",
                table: "TestAppointments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestAppointments_TestRecordId",
                table: "TestAppointments",
                column: "TestRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAppointments_TestRecordId2",
                table: "TestAppointments",
                column: "TestRecordId2",
                unique: true,
                filter: "[TestRecordId2] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAppointments_TestRecords_TestRecordId2",
                table: "TestAppointments",
                column: "TestRecordId2",
                principalTable: "TestRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAppointments_TestTypes_TestTypeId",
                table: "TestAppointments",
                column: "TestTypeId",
                principalTable: "TestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAppointments_TestRecords_TestRecordId2",
                table: "TestAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAppointments_TestTypes_TestTypeId",
                table: "TestAppointments");

            migrationBuilder.DropIndex(
                name: "IX_TestAppointments_TestRecordId",
                table: "TestAppointments");

            migrationBuilder.DropIndex(
                name: "IX_TestAppointments_TestRecordId2",
                table: "TestAppointments");

            migrationBuilder.DropColumn(
                name: "TestRecordId2",
                table: "TestAppointments");

            migrationBuilder.CreateTable(
                name: "DetailsTestRecordVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportStatus = table.Column<int>(type: "int", nullable: false),
                    TestRecordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsTestRecordVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailsTestRecordVM_TestRecords_TestRecordId",
                        column: x => x.TestRecordId,
                        principalTable: "TestRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TestAppointments_TestRecordId",
                table: "TestAppointments",
                column: "TestRecordId",
                unique: true,
                filter: "[TestRecordId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsTestRecordVM_TestRecordId",
                table: "DetailsTestRecordVM",
                column: "TestRecordId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TestAppointments_TestTypes_TestTypeId",
                table: "TestAppointments",
                column: "TestTypeId",
                principalTable: "TestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
