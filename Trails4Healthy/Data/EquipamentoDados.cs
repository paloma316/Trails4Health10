using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Healthy.Models;

namespace Trails4Healthy.Data
{
    public class EquipamentoDados:Interface
    {
        public IEnumerable<Equipamento> Equipamentos => new List<Equipamento> {
new Equipamento { NomeEquipamento= "Football", ValorUnidade= 25 },
new Equipamento { NomeEquipamento = "Surf board", ValorUnidade = 179 },
new Equipamento { NomeEquipamento = "Running shoes", ValorUnidade = 95 }
};

        
    }
}
