using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public interface Interface
    {
        IEnumerable<Equipamento> Equipamentos { get; }
    }
}
