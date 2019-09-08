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
    public class LearningOutcomeModelsController : Controller
    {
        private readonly LearningOutcomeContext _context;

        public LearningOutcomeModelsController(LearningOutcomeContext context)
        {
            _context = context;
        }

        // GET: LearningOutcomeModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.LearningOutcomes.ToListAsync());
        }

        // GET: LearningOutcomeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningOutcomeModel = await _context.LearningOutcomes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (learningOutcomeModel == null)
            {
                return NotFound();
            }

            return View(learningOutcomeModel);
        }

        // GET: LearningOutcomeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LearningOutcomeModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,CourseInstanceID")] LearningOutcomeModel learningOutcomeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learningOutcomeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(learningOutcomeModel);
        }

        // GET: LearningOutcomeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningOutcomeModel = await _context.LearningOutcomes.FindAsync(id);
            if (learningOutcomeModel == null)
            {
                return NotFound();
            }
            return View(learningOutcomeModel);
        }

        // POST: LearningOutcomeModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,CourseInstanceID")] LearningOutcomeModel learningOutcomeModel)
        {
            if (id != learningOutcomeModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learningOutcomeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearningOutcomeModelExists(learningOutcomeModel.ID))
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
            return View(learningOutcomeModel);
        }

        // GET: LearningOutcomeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningOutcomeModel = await _context.LearningOutcomes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (learningOutcomeModel == null)
            {
                return NotFound();
            }

            return View(learningOutcomeModel);
        }

        // POST: LearningOutcomeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learningOutcomeModel = await _context.LearningOutcomes.FindAsync(id);
            _context.LearningOutcomes.Remove(learningOutcomeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearningOutcomeModelExists(int id)
        {
            return _context.LearningOutcomes.Any(e => e.ID == id);
        }
    }
}
