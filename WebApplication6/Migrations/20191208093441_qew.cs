using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication6.Migrations
{
    public partial class qew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecificationId",
                table: "Labas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Labas_SpecificationId",
                table: "Labas",
                column: "SpecificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labas_Specifications_SpecificationId",
                table: "Labas",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labas_Specifications_SpecificationId",
                table: "Labas");

            migrationBuilder.DropIndex(
                name: "IX_Labas_SpecificationId",
                table: "Labas");

            migrationBuilder.DropColumn(
                name: "SpecificationId",
                table: "Labas");
        }
    }
}
