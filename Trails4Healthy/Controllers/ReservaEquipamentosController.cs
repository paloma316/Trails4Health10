using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        //---------------


        /* public ReservaEquipamentosController(TrailsDbContext dbContext)
         {
             dbContext = _contextUser;
         }*/

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
        /*
        [Authorize(Roles = "Customer")]
        public IActionResult Create(int? id)
        {
            //ir Buscar id do turista
            if (id == null)
            {
                return NotFound();
            }

            var reservaEquipamentos = await _context.ReservaEquipamentos.SingleOrDefaultAsync(m => m.ReservaId == id);
            ViewData["TrilhoId"] = new SelectList(_context.Trails, "TrailID", "Name");
            ViewData["TuristaId"] = new SelectList(_context.Turistas, "TuristaId", "Nome");
            return base.View();
        }
        /*
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create()
        {
            //codigo para ir buscar o utilizador na base de dado TrailsUser
            //User.Identity.Name

            //SingleorDefault:retorna toda a informacao
           var nomeUser = User.Identity.Name;
           var turista= await _context.Turistas.SingleOrDefaultAsync(t => t.username == nomeUser);

        
          //  if(idTurista=User.Identity.Name)
           
   // .SingleOrDefaultAsync(m => m.ReservaId == id);
   if (idTurista == null)
   {
       return NotFound();
   }
 //  ViewData["TuristaId"] = new SelectList(_context.Turistas, "TuristaId", "Id do Turista que fez o Login");

   ViewData["TrilhoId"] = new SelectList(_context.Trails, "TrailID", "Name");
  // ViewData["TuristaId"] = new SelectList(_context.Turistas, "TuristaId", "Nome");
   return base.View();
}*/


        //------------------------------
        // GET: ReservaEquipamentos/Create
        [Authorize(Roles = "Customer")]
        public IActionResult Create()
        {
            ViewData["TrilhoId"] = new SelectList(_context.Trails, "TrailID", "Name");

            return View();
        }


        //--------------------------------

        // POST: ReservaEquipamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

       
        public async Task<IActionResult> Create([Bind("ReservaId,TuristaId,TrilhoId,Data_Reserva_Efetuada,Inicio_Reserva")] ReservaEquipamentos reservaEquipamentos)
        {
            if (ModelState.IsValid)
            {
                var nomeUser = User.Identity.Name;
                var turista = await _context.Turistas.SingleOrDefaultAsync(t => t.username == nomeUser);
                reservaEquipamentos.Turistas = turista;


                _context.Add(reservaEquipamentos);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(View));
                return View();
            
            }
            ViewData["TrilhoId"] = new SelectList(_context.Trails, "TrailID", "TrailID", reservaEquipamentos.TrilhoId);
            //  ViewData["TuristaId"] = new SelectList(_context.Turistas, "TuristaId", "TuristaId", reservaEquipamentos.TuristaId);
           
            

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
        //Index
        //------------------


        //----------------

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
                return RedirectToAction(nameof(View));
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

        //acao para o turista  visualizar as suas reservas 


        // POST: ReservaEquipamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaEquipamentos = await _context.ReservaEquipamentos.SingleOrDefaultAsync(m => m.ReservaId == id);
            _context.ReservaEquipamentos.Remove(reservaEquipamentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(View));
        }

        private bool ReservaEquipamentosExists(int id)
        {
            return _context.ReservaEquipamentos.Any(e => e.ReservaId == id);
        }
    }
}
