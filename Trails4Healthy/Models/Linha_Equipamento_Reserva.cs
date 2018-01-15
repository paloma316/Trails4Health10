using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class Linha_Equipamento_Reserva
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinhaEquipamentoId { get; set; }
        public int EquipamentoId { get; set; }
        public int ReservaId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorParcial { get;set; }

         public ReservaEquipamentos Reservas { get; set; }
         public Equipamento Equipamentos { get; set; }



    }
}
