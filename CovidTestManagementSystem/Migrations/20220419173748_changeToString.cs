using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidTestManagementSystem.Migrations
{
    public partial class changeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRecords_AspNetUsers_PatientId1",
                table: "TestRecords");

            migrationBuilder.DropIndex(
                name: "IX_TestRecords_PatientId1",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "TestRecords");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "TestRecords",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DetailsTestRecordVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestRecordId = table.Column<int>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_PatientId",
                table: "TestRecords",
                column: "PatientId");

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
                name: "FK_TestRecords_AspNetUsers_PatientId",
                table: "TestRecords",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRecords_AspNetUsers_PatientId",
                table: "TestRecords");

            migrationBuilder.DropTable(
                name: "DetailsTestRecordVM");

            migrationBuilder.DropTable(
                name: "TestAppointmentVM");

            migrationBuilder.DropIndex(
                name: "IX_TestRecords_PatientId",
                table: "TestRecords");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "TestRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientId1",
                table: "TestRecords",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_PatientId1",
                table: "TestRecords",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TestRecords_AspNetUsers_PatientId1",
                table: "TestRecords",
                column: "PatientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
