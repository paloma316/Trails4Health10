using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class Linha_Equipamento_Reserva
    {

        public int EquipamentoId { get; set; }
        public int ReservaId { get; set; }

        public ReservaEquipamentos Reservas { get; set; }
        public Equipamento Equipamentos { get; set; }
    }
}
