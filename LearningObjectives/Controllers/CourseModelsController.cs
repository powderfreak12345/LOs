using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFGetStarted.AspNetCore.NewDb.Models;
using LearningObjectives.Data;

namespace LearningObjectives.Controllers
{
    public class CourseModelsController : Controller
    {
        private readonly Db _context;

        public CourseModelsController(Db context)
        {
            _context = context;
        }

        // GET: CourseModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }

        // GET: CourseModels/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var courseModel = await _context.Courses
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (courseModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(courseModel);
        //}

        // GET: CourseModels/Details?dept=a&courseNumber=b&semester=c&year=d
        // EXAMPLE: /CourseModels/Details?dept=School+of+Computing&courseNumber=4540&semester=Fall&year=2019
        //  This is how the parameters are passed to the controller
        public async Task<IActionResult> Details(string dept, int courseNumber, string semester, int year)
        {
            // Try to retrieve the course from database.  Sanitize inputs.
            var courseModel = await RetrieveCourseModel(dept, courseNumber, semester, year);

            if (courseModel == null)
            {
                // Return the error page here. TODO: Make a better error page explaining the error
                return NotFound();
            }

            return View(courseModel);
        }

        // GET: CourseModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Number,Name,Description,Department,Year,Semester")] CourseModel courseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseModel);
        }

        // GET: CourseModels/Edit/5
        public async Task<IActionResult> Edit(string dept, int courseNumber, string semester, int year)
        {
            // Try to retrieve the course from database.  Sanitize inputs.
            var courseModel = await RetrieveCourseModel(dept, courseNumber, semester, year);
            if (courseModel == null)
            {
                return NotFound();
            }
            return View(courseModel);
        }

        // POST: CourseModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Number,Name,Description,Department,Year,Semester")] CourseModel courseModel)
        {
            if (id != courseModel.CourseModelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseModelExists(courseModel.CourseModelID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(courseModel);
        }

        // GET: CourseModels/Delete/5
        public async Task<IActionResult> Delete(string dept, int courseNumber, string semester, int year)
        {
            // Try to retrieve the course from database.  Sanitize inputs.
            var courseModel = await RetrieveCourseModel(dept, courseNumber, semester, year);

            if (courseModel == null)
            {
                return NotFound();
            }

            return View(courseModel);
        }

        // POST: CourseModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseModel = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(courseModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseModelExists(int id)
        {
            return _context.Courses.Any(e => e.CourseModelID == id);
        }

        private async Task<CourseModel> RetrieveCourseModel(string dept, int? courseNumber, string semester, int? year)
        {
            if (dept == null || courseNumber == null || semester == null || year == null)
                return null;
            
            // Try to retrieve the course from database.  Sanitize inputs.
            var course = await _context.Courses
                .FromSql("SELECT * FROM Courses WHERE Department={0} AND Number={1} AND Semester={2} AND Year={3}",
                dept, courseNumber, semester, year).FirstOrDefaultAsync();

            // Load the Learning Outcomes
            _context.Entry(course).Collection(c => c.LearningOutcomes).Load();

            foreach (LearningOutcomeModel lo in course.LearningOutcomes)
            {
                _context.Entry(lo).Collection(d => d.EvaluationMetrics).Load();
            }

            return course;
        }
    }
}
