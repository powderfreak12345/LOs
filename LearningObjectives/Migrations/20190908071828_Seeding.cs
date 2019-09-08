﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningObjectives.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add a course to the database
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Number", "Name", "Description", "Department", "Year", "Semester" },
                values: new object[] { 4540, "Web Software Architecture", "A difficult course", "School of Computing", 2019, "Fall" });

            // Add a learning outcome that is associated with the course to the database. 
            migrationBuilder.InsertData(
                table: "LearningOutcomes",
                columns: new[] { "Name", "Description", "CourseInstanceID" },
                values: new object[] { "LO-1", "(Description of LO-1)", 1 });

            // Add another learning outcome that is associated with the course to the database. 
            migrationBuilder.InsertData(
                table: "LearningOutcomes",
                columns: new[] { "Name", "Description", "CourseInstanceID" },
                values: new object[] { "LO-2", "(Description of LO-2)", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}