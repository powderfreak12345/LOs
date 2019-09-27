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

namespace LearningObjectives.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("Admin/LearningOutcome/[Action]")]
    public class AdminLearningOutcomeController : Controller
    {
        private readonly Db _context;

        public AdminLearningOutcomeController(Db context)
        {
            _context = context;
        }

        // GET: Admin/LearningOutcome
        public async Task<IActionResult> Index()
        {
            var db = _context.LearningOutcomes.Include(l => l.Course);
            return View(await db.ToListAsync());
        }

        // GET: Admin/LearningOutcome/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningOutcome = await _context.LearningOutcomes
                .Include(l => l.Course)
                .FirstOrDefaultAsync(m => m.LearningOutcomeID == id);
            if (learningOutcome == null)
            {
                return NotFound();
            }

            return View(learningOutcome);
        }

        // GET: Admin/LearningOutcome/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
            return View();
        }

        // POST: Admin/LearningOutcome/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LearningOutcomeID,CourseID,Name,Description")] LearningOutcome learningOutcome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learningOutcome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", learningOutcome.CourseID);
            return View(learningOutcome);
        }

        // GET: Admin/LearningOutcome/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningOutcome = await _context.LearningOutcomes.FindAsync(id);
            if (learningOutcome == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", learningOutcome.CourseID);
            return View(learningOutcome);
        }

        // POST: Admin/LearningOutcome/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LearningOutcomeID,CourseID,Name,Description")] LearningOutcome learningOutcome)
        {
            if (id != learningOutcome.LearningOutcomeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learningOutcome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearningOutcomeExists(learningOutcome.LearningOutcomeID))
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", learningOutcome.CourseID);
            return View(learningOutcome);
        }

        // GET: Admin/LearningOutcome/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningOutcome = await _context.LearningOutcomes
                .Include(l => l.Course)
                .FirstOrDefaultAsync(m => m.LearningOutcomeID == id);
            if (learningOutcome == null)
            {
                return NotFound();
            }

            return View(learningOutcome);
        }

        // POST: Admin/LearningOutcome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learningOutcome = await _context.LearningOutcomes.FindAsync(id);
            _context.LearningOutcomes.Remove(learningOutcome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearningOutcomeExists(int id)
        {
            return _context.LearningOutcomes.Any(e => e.LearningOutcomeID == id);
        }
    }
}
