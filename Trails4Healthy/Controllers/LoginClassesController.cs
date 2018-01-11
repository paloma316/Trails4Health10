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
    public class LoginClassesController : Controller
    {
        private readonly TrailsDbContext _context;

        public LoginClassesController(TrailsDbContext context)
        {
            _context = context;
        }

        // GET: LoginClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Turistas.ToListAsync());
        }

        // GET: LoginClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginClass = await _context.Turistas
                .SingleOrDefaultAsync(m => m.TuristaId == id);
            if (loginClass == null)
            {
                return NotFound();
            }

            return View(loginClass);
        }

        // GET: LoginClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoginClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TuristaId,username,Pass,Nome,Numero_Telefone,Morada")] LoginClass loginClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loginClass);
        }

        // GET: LoginClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginClass = await _context.Turistas.SingleOrDefaultAsync(m => m.TuristaId == id);
            if (loginClass == null)
            {
                return NotFound();
            }
            return View(loginClass);
        }

        // POST: LoginClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TuristaId,username,Pass,Nome,Numero_Telefone,Morada")] LoginClass loginClass)
        {
            if (id != loginClass.TuristaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginClassExists(loginClass.TuristaId))
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
            return View(loginClass);
        }

        // GET: LoginClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginClass = await _context.Turistas
                .SingleOrDefaultAsync(m => m.TuristaId == id);
            if (loginClass == null)
            {
                return NotFound();
            }

            return View(loginClass);
        }

        // POST: LoginClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loginClass = await _context.Turistas.SingleOrDefaultAsync(m => m.TuristaId == id);
            _context.Turistas.Remove(loginClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginClassExists(int id)
        {
            return _context.Turistas.Any(e => e.TuristaId == id);
        }
    }
}
