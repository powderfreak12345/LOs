using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFGetStarted.AspNetCore.NewDb.Models;
using LearningObjectives.Data;
using Microsoft.AspNetCore.Authorization;

namespace LearningObjectives.Controllers.Instructor
{

    [Authorize(Roles = "Instructor")]
    [Route("Instructor/Course/[Action]")]
    public class InstructorCourseController : Controller
    {
        private readonly Db _context;

        public InstructorCourseController(Db context)
        {
            _context = context;
        }

        // GET: CourseModels
        public async Task<IActionResult> Index()
        {
            // Extract the instructor's ID.  Use it to only query his/her courses
            string userID = User.Claims.First().Value;

            List<Course> courses = await _context.Courses
                .FromSql("SELECT * FROM Courses WHERE InstructorID={0}",
                userID).ToListAsync();

            // Attach the Learning Outcomes and evaluation metrics
            foreach (Course course in courses)
            {
                // Load the Learning Outcomes
                _context.Entry(course).Collection(c => c.LearningOutcomes).Load();

                // Load the Evaluation Metrics
                foreach (LearningOutcome lo in course.LearningOutcomes)
                {
                    _context.Entry(lo).Collection(d => d.EvaluationMetrics).Load();
                }
            }
            return View(courses);
        }


        // GET: CourseModels/Details?dept=a&courseNumber=b&semester=c&year=d
        // EXAMPLE: /CourseModels/Details?dept=School+of+Computing&courseNumber=4540&semester=Fall&year=2019
        //  This is how the parameters are passed to the controller
        public async Task<IActionResult> Details(string dept, int courseNumber, string semester, int year)
        {
            string instructorId = User.Claims.First().Value;

            // Try to retrieve the course from database.  Sanitize inputs.
            var courseModel = await RetrieveCourseModel(dept, courseNumber, semester, year, instructorId);

            if (courseModel == null)
            {
                // Return the error page here. TODO: Make a better error page explaining the error
                return NotFound();
            }

            return View(courseModel);
        }

        private bool CourseModelExists(int id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }

        private async Task<Course> RetrieveCourseModel(string dept, int? courseNumber, string semester, int? year, string instructorID)
        {
            if (dept == null || courseNumber == null || semester == null || year == null)
                return null;

            // Try to retrieve the course from database.  Sanitize inputs.
            var course = await _context.Courses
                .FromSql("SELECT * FROM Courses WHERE Department={0} AND Number={1} AND Semester={2} AND Year={3} AND InstructorID={4}",
                dept, courseNumber, semester, year, instructorID).FirstOrDefaultAsync();

            if (course == null)
            {
                return null;
            }

            // Load the Learning Outcomes
            _context.Entry(course).Collection(c => c.LearningOutcomes).Load();

            // Load the Evaluation Metrics
            foreach (LearningOutcome lo in course.LearningOutcomes)
            {
                _context.Entry(lo).Collection(d => d.EvaluationMetrics).Load();
            }

            return course;
        }

        private bool UserIsInstructor()
        {
            var professorTest = User.Claims.Where(o => o.Value == "Instructor");
            if (professorTest.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
