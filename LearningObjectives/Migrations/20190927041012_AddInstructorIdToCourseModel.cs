using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningObjectives.Migrations
{
    public partial class AddInstructorIdToCourseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstructorID",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstructorID",
                table: "Courses");
        }
    }
}
