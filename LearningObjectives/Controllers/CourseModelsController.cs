using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFGetStarted.AspNetCore.NewDb.Models;

namespace LearningObjectives.Controllers
{
    public class CourseModelsController : Controller
    {
        private readonly LearningOutcomeContext _context;

        public CourseModelsController(LearningOutcomeContext context)
        {
            _context = context;
        }

        // GET: CourseModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }



        // GET: CourseModels/Details?dept=a&courseNumber=b&semester=c&year=d
        // EXAMPLE: /CourseModels/Details?dept=School+of+Computing&courseNumber=4540&semester=Fall&year=2019
        //  This is how the parameters are passed to the controller
        public async Task<IActionResult> Details(string dept, int courseNumber, string semester, int year)
        {
            // Try to retrieve the course from database.  Sanitize inputs.
            var course = await _context.Courses.FromSql("SELECT * FROM Courses" +
                                                        " WHERE Department={0}" +
                                                        " AND Number={1}" +
                                                        " AND Semester={2}" +
                                                        " AND Year={3}",
                                                        dept, courseNumber, semester, year).FirstOrDefaultAsync();

            if (course == null)
            {
                // Return the error page here. TODO: Make a better error page explaining the error
                return NotFound();
            }

            // Old version of an html string that would have described the course.  Might still use later...
            //string name = ((CourseModel)course).Name;
            //string description = ((CourseModel)course).Description;
            //string html_retval = "<h>Basic course info:</h>" +
            //                     "<p>Name: " + name + "</p>" +
            //                     "<p>Desctiption: " + description + "</p>" +
            //                     "<p>Department: " + dept + "</p>" +
            //                     "<p>Number: " + courseNumber + "</p>" +
            //                     "<p>Semester: " + semester + "</p>" +
            //                     "<p>Year:  " + year + "</p>";

            // TODO: Figure out how to return this as an html string instead
            return View(course);            
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
        public async Task<IActionResult> Create([Bind("ID,Number,Name,Description,Department,Year")] CourseModel courseModel)
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseModel = await _context.Courses.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Number,Name,Description,Department,Year")] CourseModel courseModel)
        {
            if (id != courseModel.ID)
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
                    if (!CourseModelExists(courseModel.ID))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseModel = await _context.Courses
                .FirstOrDefaultAsync(m => m.ID == id);
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
            return _context.Courses.Any(e => e.ID == id);
        }
    }
}
