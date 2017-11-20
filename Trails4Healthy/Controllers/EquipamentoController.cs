using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trails4Healthy.Models;

namespace Trails4Healthy.Controllers
{
    public class EquipamentoController : Controller
    {
        private InterfaceEquipamento repository;
        public EquipamentoController(InterfaceEquipamento repository)
        {
            this.repository = repository;
        }
        public ViewResult Index() => View(repository.Equipamentos);

    }
}