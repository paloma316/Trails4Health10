using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trails4Healthy.Models;



namespace Trails4Healthy.Controllers
{
    public class TrailsController : Controller
    {
        [HttpGet]

        public ViewResult NewTrail()
        {
            return View();
        }
        [HttpPost]
        public ViewResult NewTrail(CreateTrail Trails)
        {

            if (ModelState.IsValid)
            {

                Repository.AddCreateTrail(Trails);

                //todo: add guest to the list
                return View("Thanks", Trails);
            }
            else
            {
                //there are validation errors
                return View();
            }
        }

        public IActionResult ViewTrails()
        {
            return View();
        }

    }
}
