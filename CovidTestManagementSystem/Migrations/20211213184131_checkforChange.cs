using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidTestManagementSystem.Migrations
{
    public partial class checkforChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestAppointmentId",
                table: "TestRecordVM",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "TestRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestAppointmentId",
                table: "TestRecords",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestRecordVM_TestAppointmentId",
                table: "TestRecordVM",
                column: "TestAppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRecords_TestAppointmentId",
                table: "TestRecords",
                column: "TestAppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestRecords_TestAppointments_TestAppointmentId",
                table: "TestRecords",
                column: "TestAppointmentId",
                principalTable: "TestAppointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestRecordVM_TestAppointments_TestAppointmentId",
                table: "TestRecordVM",
                column: "TestAppointmentId",
                principalTable: "TestAppointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRecords_TestAppointments_TestAppointmentId",
                table: "TestRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TestRecordVM_TestAppointments_TestAppointmentId",
                table: "TestRecordVM");

            migrationBuilder.DropIndex(
                name: "IX_TestRecordVM_TestAppointmentId",
                table: "TestRecordVM");

            migrationBuilder.DropIndex(
                name: "IX_TestRecords_TestAppointmentId",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "TestAppointmentId",
                table: "TestRecordVM");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "TestAppointmentId",
                table: "TestRecords");
        }
    }
}
