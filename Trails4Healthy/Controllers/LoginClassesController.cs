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
        string linhaEquipamento;
        int reservaId=0;

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


        //acao para o turista  visualizar as suas reservas 
        public async Task<IActionResult> ReservasTurista(int? id)
        {
            /*
            var trailsDbContext = _context.ReservaEquipamentos.Include(r => r.Trails).Include(r => r.Turistas);
            return View(await trailsDbContext.ToListAsync());
             */
            if (id == null)
            {
                return NotFound();
            }
           

            /*var loginClass = await _context.Turistas
                .SingleOrDefaultAsync(m => m.TuristaId == id);*/
            // var turista = await _context.Turistas.SingleOrDefaultAsync(t => t.username == nomeUser);
            //  var Reserva1Turista =await _context.ReservaEquipamentos.SingleOrDefaultAsync(t => t.TuristaId == id);
            // var Reserva1Turista = await _context.ReservaEquipamentos.Where(r => r.TuristaId == id).ToListAsync();
            var Reserva1Turista = await _context.ReservaEquipamentos.Include(trilho=>trilho.Trails).Where(r => r.TuristaId == id).ToListAsync();
           
         // linhaEquipamento= _context.ReservaEquipamentos.Include(r => r.Trails).Include(r => r.Turistas);

            // return View(await trailsDbContext.ToListAsync());

            return View(Reserva1Turista);
        }


        //Linha Reserva Equipamento
        // GET: Linha_Equipamento_Reserva
       
        public async Task<IActionResult> CriarLinhaEquipamento(int id)
        {

            //  var trailsDbContext = _context.Linha_Equipamento.Include(l => l.Equipamentos).Include(l => l.Reservas);

            //var Reserva1Turista = await _context.ReservaEquipamentos.Where(r => r.TuristaId == id).ToListAsync();


            // var linhaEquipamento = _context.Linha_Equipamento.Include(l => l.Equipamentos).Where(r=>r.ReservaId ==id);
            // return View(await trailsDbContext.ToListAsync());

            var linhaEquipamento = _context.Linha_Equipamento.Include(l => l.Equipamentos).Where(r => r.ReservaId == id);
            //reservaEquipamentos.Turistas = turista;
           
                reservaId = id;
          

            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "EquipamentoId", "EquipamentoId");
            return View();

        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarLinhaEquipamento([Bind("LinhaEquipamentoId,EquipamentoId,ReservaId,Quantidade,ValorParcial")] Linha_Equipamento_Reserva linha_Equipamento_Reserva)
        {

            /*  var nomeUser = User.Identity.Name;
                            var turista = await _context.Turistas.SingleOrDefaultAsync(t => t.username == nomeUser);
                            reservaEquipamentos.Turistas = turista;


                            _context.Add(reservaEquipamentos);
                            await _context.SaveChangesAsync();*/


            


            if (ModelState.IsValid)
            {
                //var trailsDbContext =  _context.Linha_Equipamento.SingleOrDefault(r=>r.ReservaId==id);
                //linha_Equipamento_Reserva. = trailsDbContext;
                reservaId = linha_Equipamento_Reserva.ReservaId;
                _context.Add(linha_Equipamento_Reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "EquipamentoId", "EquipamentoId", linha_Equipamento_Reserva.EquipamentoId);
            ViewData["ReservaId"] = new SelectList(_context.ReservaEquipamentos, "ReservaId", "ReservaId", linha_Equipamento_Reserva.ReservaId);
            return View(linha_Equipamento_Reserva);
        }

    }
}
