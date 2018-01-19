using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Trails4Healthy.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Trail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrailID { get; set; }
        [Required(ErrorMessage = "INTRODUZA O NOME")]
        public string Name { get; set; }
        [Required(ErrorMessage = "INTRODUZA A DISTÂNCIA")]
        [RegularExpression(@"\d+(\.\d{0,2})?", ErrorMessage = "Introduza uma distância válida, só pode ser numérica, opção de duas casas decimais")]
        public string Distance { get; set; }
        public int DifficultyId { get; set; }
        public Difficulty Difficulty { get; set; }
        public bool Available { get; set; }


        //
        public ICollection<ReservaEquipamentos> reservaEquipamentos1 { get; set; }
        
    }
}
