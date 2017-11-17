using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class Equipamento
    {
        public int Id_Equipamento { get; set; }
        public string DescricaoEquipamento { get; set; }
        public decimal ValorUnidade { get; set; }
        public string NomeEquipamento { get; set; }
    }
}
