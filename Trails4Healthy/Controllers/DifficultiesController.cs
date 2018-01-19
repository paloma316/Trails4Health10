using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trails4Healthy.Data;
using Trails4Healthy.Models;

namespace Trails4Healthy.Controllers
{
    public class DifficultiesController : Controller
    {
        private readonly TrailsDbContext _context;

        public DifficultiesController(TrailsDbContext context)
        {
            _context = context;
        }

        // GET: Difficulties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Difficulties.ToListAsync());
        }

        // GET: Difficulties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var difficulty = await _context.Difficulties
                .SingleOrDefaultAsync(m => m.DifficultyId == id);
            if (difficulty == null)
            {
                return NotFound();
            }

            return View(difficulty);
        }

        // GET: Difficulties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Difficulties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DifficultyId,Name")] Difficulty difficulty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(difficulty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(difficulty);
        }

        // GET: Difficulties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var difficulty = await _context.Difficulties.SingleOrDefaultAsync(m => m.DifficultyId == id);
            if (difficulty == null)
            {
                return NotFound();
            }
            return View(difficulty);
        }

        // POST: Difficulties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DifficultyId,Name")] Difficulty difficulty)
        {
            if (id != difficulty.DifficultyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(difficulty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DifficultyExists(difficulty.DifficultyId))
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
            return View(difficulty);
        }

        // GET: Difficulties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var difficulty = await _context.Difficulties
                .SingleOrDefaultAsync(m => m.DifficultyId == id);
            if (difficulty == null)
            {
                return NotFound();
            }

            return View(difficulty);
        }

        // POST: Difficulties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var difficulty = await _context.Difficulties.SingleOrDefaultAsync(m => m.DifficultyId == id);
            _context.Difficulties.Remove(difficulty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DifficultyExists(int id)
        {
            return _context.Difficulties.Any(e => e.DifficultyId == id);
        }
    }
}
