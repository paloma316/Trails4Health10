using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class Estado_Reserva
    {
        public int EstadoId { get; set; }
        public int ReservaId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio_Reserva { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataFim_Reserva { get; set; }

        public string CausaEstado { get; set; }


        public Estado Estado { get; set; }
        public ReservaEquipamentos Reservas { get; set; }
    }
}
