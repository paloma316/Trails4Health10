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
    public class ReservaEquipamentosController : Controller
    {
        private readonly TrailsDbContext _context;

        public ReservaEquipamentosController(TrailsDbContext context)
        {
            _context = context;
        }

        // GET: ReservaEquipamentos
        public async Task<IActionResult> Index()
        {
            var trailsDbContext = _context.ReservaEquipamentos.Include(r => r.Trails).Include(r => r.Turistas);
            return View(await trailsDbContext.ToListAsync());
        }

        // GET: ReservaEquipamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaEquipamentos = await _context.ReservaEquipamentos
                .Include(r => r.Trails)
                .Include(r => r.Turistas)
                .SingleOrDefaultAsync(m => m.ReservaId == id);
            if (reservaEquipamentos == null)
            {
                return NotFound();
            }

            return View(reservaEquipamentos);
        }

      
        

        // GET: ReservaEquipamentos/Create
        public IActionResult Create()
        {
            ViewData["TrilhoId"] = new SelectList(_context.Trails, "TrailID", "Name");
            ViewData["TuristaId"] = new SelectList(_context.Turistas, "TuristaId", "Nome");
            return View();
        }

        // POST: ReservaEquipamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservaId,TuristaId,TrilhoId,Data_Reserva_Efetuada,Inicio_Reserva")] ReservaEquipamentos reservaEquipamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaEquipamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrilhoId"] = new SelectList(_context.Trails, "TrailID", "TrailID", reservaEquipamentos.TrilhoId);
            ViewData["TuristaId"] = new SelectList(_context.Turistas, "TuristaId", "TuristaId", reservaEquipamentos.TuristaId);
            return View(reservaEquipamentos);
        }

        // GET: ReservaEquipamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaEquipamentos = await _context.ReservaEquipamentos.SingleOrDefaultAsync(m => m.ReservaId == id);
            if (reservaEquipamentos == null)
            {
                return NotFound();
            }
            ViewData["TrilhoId"] = new SelectList(_context.Trails, "TrailID", "TrailID", reservaEquipamentos.TrilhoId);
            ViewData["TuristaId"] = new SelectList(_context.Turistas, "TuristaId", "TuristaId", reservaEquipamentos.TuristaId);
            return View(reservaEquipamentos);
        }

        // POST: ReservaEquipamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaId,TuristaId,TrilhoId,Data_Reserva_Efetuada,Inicio_Reserva")] ReservaEquipamentos reservaEquipamentos)
        {
            if (id != reservaEquipamentos.ReservaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaEquipamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaEquipamentosExists(reservaEquipamentos.ReservaId))
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
            ViewData["TrilhoId"] = new SelectList(_context.Trails, "TrailID", "TrailID", reservaEquipamentos.TrilhoId);
            ViewData["TuristaId"] = new SelectList(_context.Turistas, "TuristaId", "TuristaId", reservaEquipamentos.TuristaId);
            return View(reservaEquipamentos);
        }

        // GET: ReservaEquipamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaEquipamentos = await _context.ReservaEquipamentos
                .Include(r => r.Trails)
                .Include(r => r.Turistas)
                .SingleOrDefaultAsync(m => m.ReservaId == id);
            if (reservaEquipamentos == null)
            {
                return NotFound();
            }

            return View(reservaEquipamentos);
        }

        // POST: ReservaEquipamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaEquipamentos = await _context.ReservaEquipamentos.SingleOrDefaultAsync(m => m.ReservaId == id);
            _context.ReservaEquipamentos.Remove(reservaEquipamentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaEquipamentosExists(int id)
        {
            return _context.ReservaEquipamentos.Any(e => e.ReservaId == id);
        }
    }
}
