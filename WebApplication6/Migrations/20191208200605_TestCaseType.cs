using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication6.Migrations
{
    public partial class TestCaseType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestCaseType",
                table: "TestCases",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestCaseType",
                table: "TestCases");
        }
    }
}
