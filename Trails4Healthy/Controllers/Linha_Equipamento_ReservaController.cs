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
    public class Linha_Equipamento_ReservaController : Controller
    {
        private readonly TrailsDbContext _context;

        public Linha_Equipamento_ReservaController(TrailsDbContext context)
        {
            _context = context;
        }

       


        // ORIGINAL
        // GET: Linha_Equipamento_Reserva
   
        public async Task<IActionResult> Index()
        {
             var trailsDbContext = _context.Linha_Equipamento.Include(l => l.Equipamentos).Include(l => l.Reservas);
           // var trailsDbContext = _context.Linha_Equipamento.Include(l => l.Equipamentos).Include(l => l.Reservas).Where();
            return View(await trailsDbContext.ToListAsync());
        }


        // GET: Linha_Equipamento_Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linha_Equipamento_Reserva = await _context.Linha_Equipamento
                .Include(l => l.Equipamentos)
                .Include(l => l.Reservas)
                .SingleOrDefaultAsync(m => m.ReservaId == id);
            if (linha_Equipamento_Reserva == null)
            {
                return NotFound();
            }

            return View(linha_Equipamento_Reserva);
        }

        // GET: Linha_Equipamento_Reserva/Create
        public IActionResult Create()
        {
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "EquipamentoId", "EquipamentoId");

            ViewData["ReservaId"] = new SelectList(_context.ReservaEquipamentos, "ReservaId", "ReservaId");
            return View();
        }

        // POST: Linha_Equipamento_Reserva/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinhaEquipamentoId,EquipamentoId,ReservaId,Quantidade,ValorParcial")] Linha_Equipamento_Reserva linha_Equipamento_Reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linha_Equipamento_Reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "EquipamentoId", "EquipamentoId", linha_Equipamento_Reserva.EquipamentoId);
            ViewData["ReservaId"] = new SelectList(_context.ReservaEquipamentos, "ReservaId", "ReservaId", linha_Equipamento_Reserva.ReservaId);
            return View(linha_Equipamento_Reserva);
        }

        // GET: Linha_Equipamento_Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linha_Equipamento_Reserva = await _context.Linha_Equipamento.SingleOrDefaultAsync(m => m.ReservaId == id);
            if (linha_Equipamento_Reserva == null)
            {
                return NotFound();
            }
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "EquipamentoId", "EquipamentoId", linha_Equipamento_Reserva.EquipamentoId);
            ViewData["ReservaId"] = new SelectList(_context.ReservaEquipamentos, "ReservaId", "ReservaId", linha_Equipamento_Reserva.ReservaId);
            return View(linha_Equipamento_Reserva);
        }

        // POST: Linha_Equipamento_Reserva/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LinhaEquipamentoId,EquipamentoId,ReservaId,Quantidade,ValorParcial")] Linha_Equipamento_Reserva linha_Equipamento_Reserva)
        {
            if (id != linha_Equipamento_Reserva.ReservaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linha_Equipamento_Reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Linha_Equipamento_ReservaExists(linha_Equipamento_Reserva.ReservaId))
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
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "EquipamentoId", "EquipamentoId", linha_Equipamento_Reserva.EquipamentoId);
            ViewData["ReservaId"] = new SelectList(_context.ReservaEquipamentos, "ReservaId", "ReservaId", linha_Equipamento_Reserva.ReservaId);
            return View(linha_Equipamento_Reserva);
        }

        // GET: Linha_Equipamento_Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linha_Equipamento_Reserva = await _context.Linha_Equipamento
                .Include(l => l.Equipamentos)
                .Include(l => l.Reservas)
                .SingleOrDefaultAsync(m => m.ReservaId == id);
            if (linha_Equipamento_Reserva == null)
            {
                return NotFound();
            }

            return View(linha_Equipamento_Reserva);
        }

        // POST: Linha_Equipamento_Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var linha_Equipamento_Reserva = await _context.Linha_Equipamento.SingleOrDefaultAsync(m => m.ReservaId == id);
            _context.Linha_Equipamento.Remove(linha_Equipamento_Reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Linha_Equipamento_ReservaExists(int id)
        {
            return _context.Linha_Equipamento.Any(e => e.ReservaId == id);
        }
    }
}
