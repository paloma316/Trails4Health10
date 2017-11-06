using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trails4Healthy.Models;

namespace Trails4Healthy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Fauna()
        {
            return View();
        }
        public IActionResult Flora()
        {
            return View();
        }



        public IActionResult Sobre()
        {
           
            return View();
        }

        public IActionResult Contact()
        {
            

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
