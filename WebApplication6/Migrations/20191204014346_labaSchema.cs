using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication6.Migrations
{
    public partial class labaSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Labas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LabaStatus = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Labas_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    AuthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requirments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    SpecificationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requirments_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 2046, nullable: true),
                    RequirmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCases_Requirments_RequirmentId",
                        column: x => x.RequirmentId,
                        principalTable: "Requirments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabaCases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TestCaseId = table.Column<int>(nullable: false),
                    RequirmentId = table.Column<int>(nullable: false),
                    LabaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabaCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabaCases_Labas_LabaId",
                        column: x => x.LabaId,
                        principalTable: "Labas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LabaCases_Requirments_RequirmentId",
                        column: x => x.RequirmentId,
                        principalTable: "Requirments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LabaCases_TestCases_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TestCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabaCases_LabaId",
                table: "LabaCases",
                column: "LabaId");

            migrationBuilder.CreateIndex(
                name: "IX_LabaCases_RequirmentId",
                table: "LabaCases",
                column: "RequirmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LabaCases_TestCaseId",
                table: "LabaCases",
                column: "TestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Labas_StudentId",
                table: "Labas",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirments_SpecificationId",
                table: "Requirments",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_AuthorId",
                table: "Specifications",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_RequirmentId",
                table: "TestCases",
                column: "RequirmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabaCases");

            migrationBuilder.DropTable(
                name: "Labas");

            migrationBuilder.DropTable(
                name: "TestCases");

            migrationBuilder.DropTable(
                name: "Requirments");

            migrationBuilder.DropTable(
                name: "Specifications");
        }
    }
}
