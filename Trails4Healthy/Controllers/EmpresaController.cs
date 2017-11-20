using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trails4Healthy.Models;
using Trails4Healthy.Data;

namespace Trails4Healthy.Controllers
{
    public class EmpresaController : Controller
    {
        private InterfaceEmpresa repository;
        public EmpresaController(InterfaceEmpresa repository)
        {
            this.repository = repository;
        }
        public ViewResult Index() => View(repository.Empresas);
    }
}