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
    public class TrailController : Controller
    {
        private readonly TrailsDbContext _context;

        public TrailController(TrailsDbContext context)
        {
            _context = context;
        }

        // GET: Trail
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            
            var trails = from s in _context.Trails
                           select s;
            switch (sortOrder)
            {
                case "Name":
                    trails = trails.OrderByDescending(s => s.Name);
                    break;
                case "Difficuly":
                    trails = trails.OrderBy(s => s.DifficultyId);
                    break;
                case "Available":
                    trails = trails.OrderBy(s => s.Available);
                    break;
                
            }
            return View(await trails.AsNoTracking().ToListAsync());
        }

        // GET: Trail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = await _context.Trails
                .Include(t => t.Difficulty)
                .SingleOrDefaultAsync(m => m.TrailID == id);
            if (trail == null)
            {
                return NotFound();
            }

            return View(trail);
        }

        // GET: Trail/Create
        public IActionResult Create()
        {
            ViewData["DifficultyId"] = new SelectList(_context.Difficulties, "DifficultyId", "Name");
            return View();
        }

        // POST: Trail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrailID,Name,Distance,DifficultyId,Available")] Trail trail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DifficultyId"] = new SelectList(_context.Difficulties, "DifficultyId", "Name", trail.DifficultyId);
            return View(trail);
        }

        // GET: Trail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = await _context.Trails.SingleOrDefaultAsync(m => m.TrailID == id);
            if (trail == null)
            {
                return NotFound();
            }
            ViewData["DifficultyId"] = new SelectList(_context.Difficulties, "DifficultyId", "Name", trail.DifficultyId);
            return View(trail);
        }

        // POST: Trail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrailID,Name,Distance,DifficultyId,Available")] Trail trail)
        {
            if (id != trail.TrailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrailExists(trail.TrailID))
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
            ViewData["DifficultyId"] = new SelectList(_context.Difficulties, "DifficultyId", "Name", trail.DifficultyId);
            return View(trail);
        }

        // GET: Trail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = await _context.Trails
                .Include(t => t.Difficulty)
                .SingleOrDefaultAsync(m => m.TrailID == id);
            if (trail == null)
            {
                return NotFound();
            }

            return View(trail);
        }

        // POST: Trail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trail = await _context.Trails.SingleOrDefaultAsync(m => m.TrailID == id);
            _context.Trails.Remove(trail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrailExists(int id)
        {
            return _context.Trails.Any(e => e.TrailID == id);
        }
    }
}
