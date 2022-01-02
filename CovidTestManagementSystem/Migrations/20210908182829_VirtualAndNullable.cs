using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidTestManagementSystem.Migrations
{
    public partial class VirtualAndNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAppointments_Nurses_NurseId",
                table: "TestAppointments");

            migrationBuilder.AlterColumn<int>(
                name: "NurseId",
                table: "TestAppointments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAppointments_Nurses_NurseId",
                table: "TestAppointments",
                column: "NurseId",
                principalTable: "Nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAppointments_Nurses_NurseId",
                table: "TestAppointments");

            migrationBuilder.AlterColumn<int>(
                name: "NurseId",
                table: "TestAppointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAppointments_Nurses_NurseId",
                table: "TestAppointments",
                column: "NurseId",
                principalTable: "Nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
