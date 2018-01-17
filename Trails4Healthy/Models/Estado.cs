using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }
        public string NomeEstado { get; set; }
        public string Descricao { get; set; }

        public ICollection<Estado_Reserva> EstadoReservas { get; set; }
    }
}
