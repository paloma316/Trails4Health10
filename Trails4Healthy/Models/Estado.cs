using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class Estado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstadoId { get; set; }
        public string NomeEstado { get; set; }
        public string Descricao { get; set; }
    }
}
