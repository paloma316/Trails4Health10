﻿using System;
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
        public ViewResult NewTrail(Trail trail)
        {

            if (ModelState.IsValid)
            {

                Repository.AddTrail(trail);

                //todo: add guest to the list
                return View("Thanks", trail);
            }
            else
            {
                //there are validation errors
                return View();
            }
        }

        public ViewResult ViewTrails()
        {
            return View(Repository.Trails);
        }
    

    }
}
