using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidTestManagementSystem.Migrations
{
    public partial class AddNewModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAppointments_TestRecords_TestRecordId",
                table: "TestAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAppointments_TestRecords_TestRecordId2",
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

            migrationBuilder.CreateIndex(
                name: "IX_TestAppointments_TestRecordId",
                table: "TestAppointments",
                column: "TestRecordId",
                unique: true,
                filter: "[TestRecordId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAppointments_TestRecords_TestRecordId",
                table: "TestAppointments",
                column: "TestRecordId",
                principalTable: "TestRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAppointments_TestRecords_TestRecordId",
                table: "TestAppointments");

            migrationBuilder.DropIndex(
                name: "IX_TestAppointments_TestRecordId",
                table: "TestAppointments");

            migrationBuilder.AddColumn<int>(
                name: "TestRecordId2",
                table: "TestAppointments",
                type: "int",
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
                name: "FK_TestAppointments_TestRecords_TestRecordId",
                table: "TestAppointments",
                column: "TestRecordId",
                principalTable: "TestRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAppointments_TestRecords_TestRecordId2",
                table: "TestAppointments",
                column: "TestRecordId2",
                principalTable: "TestRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
