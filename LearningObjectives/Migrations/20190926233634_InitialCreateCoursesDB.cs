using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningObjectives.Migrations
{
    public partial class InitialCreateCoursesDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Semester = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "LearningOutcomes",
                columns: table => new
                {
                    LearningOutcomeID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningOutcomes", x => x.LearningOutcomeID);
                    table.ForeignKey(
                        name: "FK_LearningOutcomes_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationMetrics",
                columns: table => new
                {
                    EvaluationMetricID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Complete = table.Column<bool>(nullable: false),
                    LearningOutcomeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationMetrics", x => x.EvaluationMetricID);
                    table.ForeignKey(
                        name: "FK_EvaluationMetrics_LearningOutcomes_LearningOutcomeID",
                        column: x => x.LearningOutcomeID,
                        principalTable: "LearningOutcomes",
                        principalColumn: "LearningOutcomeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationMetrics_LearningOutcomeID",
                table: "EvaluationMetrics",
                column: "LearningOutcomeID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomes_CourseID",
                table: "LearningOutcomes",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationMetrics");

            migrationBuilder.DropTable(
                name: "LearningOutcomes");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
