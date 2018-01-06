using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class LoginClass
    {
        //Turista=Utilizador
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TuristaId { get; set; }

       // [Required(ErrorMessage = "Username is required")] // make the field required
        //[Display(Name = "Username")]
        public string username { get; set; }


        //[Required(ErrorMessage = "Pass is required")]
        //[Display(Name = "Password")]
        [RegularExpression(@"\w{6}",ErrorMessage ="Tem de ter pelo menos 6 carateres")]
         public string Pass { get; set; }


        //[StringLength(50)]
        public string Nome { get; set; }

        //[RegularExpression("(2[0-9]{8})|(9[1236][0-9]{7})",ErrorMessage ="Digitos Inválidos")]
        public string Numero_Telefone { get; set; }

        public string Morada { get; set; }
        //public string Nif { get; set; }


        public ICollection<ReservaEquipamentos> Reservas { get; set; }
    }
}
