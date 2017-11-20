using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trails4Healthy.Data;

namespace Trails4Healthy.Controllers
{
    public class TuristaController : Controller
    {
        private InterfaceTurista repository;
        public TuristaController(InterfaceTurista repository)
        {
            this.repository = repository;
        }
        public ViewResult Index() => View(repository.Turistas);
    }
}