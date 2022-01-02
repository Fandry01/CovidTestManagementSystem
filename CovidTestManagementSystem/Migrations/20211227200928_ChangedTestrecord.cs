using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidTestManagementSystem.Migrations
{
    public partial class ChangedTestrecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAppointments_Nurses_NurseId",
                table: "TestAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_TestRecords_TestAppointments_AppointmentId",
                table: "TestRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TestRecords_AspNetUsers_PatientId",
                table: "TestRecords");

            migrationBuilder.DropIndex(
                name: "IX_TestRecords_AppointmentId",
                table: "TestRecords");

            migrationBuilder.DropIndex(
                name: "IX_TestRecords_PatientId",
                table: "TestRecords");

            migrationBuilder.DropIndex(
                name: "IX_TestAppointments_NurseId",
                table: "TestAppointments");

            migrationBuilder.DropIndex(
                name: "IX_TestAppointments_TestRecordId",
                table: "TestAppointments");

            migrationBuilder.DropColumn(
                name: "FinalReportStatus",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "NurseId",
                table: "TestAppointments");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "TestRecords",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "TestRecords",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NurseId",
                table: "TestRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PatientId1",
                table: "TestRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "TestRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatusId",
                table: "TestRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TestResultId",
                table: "TestRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ToLab",
                table: "TestRecords",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_NurseId",
                table: "TestRecords",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_PatientId1",
                table: "TestRecords",
                column: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_TestAppointments_TestRecordId",
                table: "TestAppointments",
                column: "TestRecordId",
                unique: true,
                filter: "[TestRecordId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TestRecords_Nurses_NurseId",
                table: "TestRecords",
                column: "NurseId",
                principalTable: "Nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestRecords_AspNetUsers_PatientId1",
                table: "TestRecords",
                column: "PatientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRecords_Nurses_NurseId",
                table: "TestRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TestRecords_AspNetUsers_PatientId1",
                table: "TestRecords");

            migrationBuilder.DropIndex(
                name: "IX_TestRecords_NurseId",
                table: "TestRecords");

            migrationBuilder.DropIndex(
                name: "IX_TestRecords_PatientId1",
                table: "TestRecords");

            migrationBuilder.DropIndex(
                name: "IX_TestAppointments_TestRecordId",
                table: "TestAppointments");

            migrationBuilder.DropColumn(
                name: "NurseId",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "ReportStatusId",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "TestResultId",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "ToLab",
                table: "TestRecords");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "TestRecords",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "TestRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "FinalReportStatus",
                table: "TestRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NurseId",
                table: "TestAppointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_AppointmentId",
                table: "TestRecords",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_PatientId",
                table: "TestRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAppointments_NurseId",
                table: "TestAppointments",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAppointments_TestRecordId",
                table: "TestAppointments",
                column: "TestRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAppointments_Nurses_NurseId",
                table: "TestAppointments",
                column: "NurseId",
                principalTable: "Nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestRecords_TestAppointments_AppointmentId",
                table: "TestRecords",
                column: "AppointmentId",
                principalTable: "TestAppointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestRecords_AspNetUsers_PatientId",
                table: "TestRecords",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
