using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AdmissionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Lookup");

            migrationBuilder.CreateTable(
                name: "Class",
                schema: "Lookup",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Option",
                schema: "Lookup",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.OptionId);
                });

            migrationBuilder.CreateTable(
                name: "Parent",
                schema: "Admission",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnic = table.Column<string>(type: "NVARCHAR(13)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.ParentId);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                schema: "Lookup",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionId);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                schema: "Admission",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "INT", nullable: false),
                    SessionId = table.Column<int>(type: "INT", nullable: false),
                    ClassId = table.Column<int>(type: "INT", nullable: false),
                    OptionOneId = table.Column<int>(type: "INT", nullable: true),
                    OptionTwoId = table.Column<int>(type: "INT", nullable: true),
                    ParentId = table.Column<int>(type: "INT", nullable: false),
                    FeePayerId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Application_Candidate",
                        column: x => x.CandidateId,
                        principalSchema: "Admission",
                        principalTable: "Candidate",
                        principalColumn: "CandidateId");
                    table.ForeignKey(
                        name: "FK_Application_Class",
                        column: x => x.ClassId,
                        principalSchema: "Lookup",
                        principalTable: "Class",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_Application_FeePayer",
                        column: x => x.FeePayerId,
                        principalSchema: "Admission",
                        principalTable: "Parent",
                        principalColumn: "ParentId");
                    table.ForeignKey(
                        name: "FK_Application_OptionOne",
                        column: x => x.OptionOneId,
                        principalSchema: "Lookup",
                        principalTable: "Option",
                        principalColumn: "OptionId");
                    table.ForeignKey(
                        name: "FK_Application_OptionTwo",
                        column: x => x.OptionTwoId,
                        principalSchema: "Lookup",
                        principalTable: "Option",
                        principalColumn: "OptionId");
                    table.ForeignKey(
                        name: "FK_Application_Parent",
                        column: x => x.ParentId,
                        principalSchema: "Admission",
                        principalTable: "Parent",
                        principalColumn: "ParentId");
                    table.ForeignKey(
                        name: "FK_Application_Session",
                        column: x => x.SessionId,
                        principalSchema: "Lookup",
                        principalTable: "Session",
                        principalColumn: "SessionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_CandidateId",
                schema: "Admission",
                table: "Application",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_ClassId",
                schema: "Admission",
                table: "Application",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_FeePayerId",
                schema: "Admission",
                table: "Application",
                column: "FeePayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_OptionOneId",
                schema: "Admission",
                table: "Application",
                column: "OptionOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_OptionTwoId",
                schema: "Admission",
                table: "Application",
                column: "OptionTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_ParentId",
                schema: "Admission",
                table: "Application",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_SessionId",
                schema: "Admission",
                table: "Application",
                column: "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application",
                schema: "Admission");

            migrationBuilder.DropTable(
                name: "Class",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Parent",
                schema: "Admission");

            migrationBuilder.DropTable(
                name: "Option",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Session",
                schema: "Lookup");
        }
    }
}
