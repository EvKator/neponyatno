using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication6.Migrations
{
    public partial class RequiementNotRequired1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabaCases_Requirments_RequirmentId",
                table: "LabaCases");

            migrationBuilder.AlterColumn<int>(
                name: "RequirmentId",
                table: "LabaCases",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "LabaCaseDto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TestCaseId = table.Column<int>(nullable: true),
                    RequirmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabaCaseDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabaCaseDto_Requirments_RequirmentId",
                        column: x => x.RequirmentId,
                        principalTable: "Requirments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabaCaseDto_TestCases_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TestCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabaCaseDto_RequirmentId",
                table: "LabaCaseDto",
                column: "RequirmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LabaCaseDto_TestCaseId",
                table: "LabaCaseDto",
                column: "TestCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabaCases_Requirments_RequirmentId",
                table: "LabaCases",
                column: "RequirmentId",
                principalTable: "Requirments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabaCases_Requirments_RequirmentId",
                table: "LabaCases");

            migrationBuilder.DropTable(
                name: "LabaCaseDto");

            migrationBuilder.AlterColumn<int>(
                name: "RequirmentId",
                table: "LabaCases",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LabaCases_Requirments_RequirmentId",
                table: "LabaCases",
                column: "RequirmentId",
                principalTable: "Requirments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
