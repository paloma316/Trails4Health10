using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Healthy.Models;

namespace Trails4Healthy.Data
{
    public interface InterfaceEmpresa
    {
       IEnumerable<Empresa> Empresas { get; }
    }
}
