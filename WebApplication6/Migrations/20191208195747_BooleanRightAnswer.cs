using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication6.Migrations
{
    public partial class BooleanRightAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RightAnswer",
                table: "LabaCases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RightAnswer",
                table: "LabaCases");
        }
    }
}
