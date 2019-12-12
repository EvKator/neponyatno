using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication6.Migrations
{
    public partial class eeeeeee2244 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labas_Specifications_SpecificationId",
                table: "Labas");

            migrationBuilder.AlterColumn<int>(
                name: "SpecificationId",
                table: "Labas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "SpecificationId",
                table: "Labas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Labas_Specifications_SpecificationId",
                table: "Labas",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
