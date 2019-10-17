using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningObjectives.Migrations
{
    public partial class AnotherDumbFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Note_Courses_CourseID",
                table: "Course_Note");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course_Note",
                table: "Course_Note");

            migrationBuilder.RenameTable(
                name: "Course_Note",
                newName: "Course_Notes");

            migrationBuilder.RenameIndex(
                name: "IX_Course_Note_CourseID",
                table: "Course_Notes",
                newName: "IX_Course_Notes_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course_Notes",
                table: "Course_Notes",
                column: "Course_NoteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Notes_Courses_CourseID",
                table: "Course_Notes",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Notes_Courses_CourseID",
                table: "Course_Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course_Notes",
                table: "Course_Notes");

            migrationBuilder.RenameTable(
                name: "Course_Notes",
                newName: "Course_Note");

            migrationBuilder.RenameIndex(
                name: "IX_Course_Notes_CourseID",
                table: "Course_Note",
                newName: "IX_Course_Note_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course_Note",
                table: "Course_Note",
                column: "Course_NoteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Note_Courses_CourseID",
                table: "Course_Note",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
