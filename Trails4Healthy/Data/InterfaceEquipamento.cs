using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public interface InterfaceEquipamento
    {
        IEnumerable<Equipamento> Equipamentos { get; }
      /*  IEnumerable<Empresa> Empresas { get; }
        IEnumerable<Turista> Turistas { get; }
        IEnumerable<Dificuldade> Dificuldades { get; }*/

    }
}
