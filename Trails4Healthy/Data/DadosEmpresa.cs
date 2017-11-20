using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Healthy.Models;

namespace Trails4Healthy.Data
{
    public class DadosEmpresa : InterfaceEmpresa
    {



        IEnumerable<Empresa> InterfaceEmpresa.Empresas => new List<Empresa>
               {
                   new Empresa{NomeEmpresa="Zimex Sport",Contactos="939503504"},
                     new Empresa{NomeEmpresa="Sport Patner",Contactos="939503599"},
                       new Empresa{NomeEmpresa="SportZone",Contactos="939503902"}
               };
    }

    }
