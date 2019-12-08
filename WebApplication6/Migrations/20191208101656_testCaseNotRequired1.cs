using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication6.Migrations
{
    public partial class testCaseNotRequired1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabaCases_TestCases_TestCaseId",
                table: "LabaCases");

            migrationBuilder.AlterColumn<int>(
                name: "TestCaseId",
                table: "LabaCases",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_LabaCases_TestCases_TestCaseId",
                table: "LabaCases",
                column: "TestCaseId",
                principalTable: "TestCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabaCases_TestCases_TestCaseId",
                table: "LabaCases");

            migrationBuilder.AlterColumn<int>(
                name: "TestCaseId",
                table: "LabaCases",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LabaCases_TestCases_TestCaseId",
                table: "LabaCases",
                column: "TestCaseId",
                principalTable: "TestCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
