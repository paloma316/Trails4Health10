using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class ReservaEquipamentos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservaId { get; set; }
        public int TuristaId { get; set; }
        public int TrilhoId { get; set; }

      //  [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data_Reserva_Efetuada  { get; set; }
        public ReservaEquipamentos()
        {
            this.Data_Reserva_Efetuada = System.DateTime.Now;
          //  this.TuristaId=
        }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Inicio_Reserva{ get; set; }


      public ICollection<Estado_Reserva>Estado_Reserva { get; set; }
        public ICollection<Linha_Equipamento_Reserva> Linha_Equipamento_Reserva { get; set; }

        public Trail Trails { get; set; }
        public LoginClass Turistas { get; set; }
        



       

    }
}
