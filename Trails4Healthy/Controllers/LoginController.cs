using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trails4Healthy.Models;

namespace Trails4Healthy.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        public IActionResult Login(LoginClass modelo)
        {
              if (ModelState.IsValid)
              {
               
                  return View("Sucesso",modelo);
              }
            else
            {
                return View();
            }
           
        }
        public IActionResult Sucesso()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}