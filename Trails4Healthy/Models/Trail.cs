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
        public string Name { get; set; }
        public string Distance { get; set; }
        public int DifficultyId { get; set; }
        public Difficulty Difficulty { get; set; }
        public bool Available { get; set; }


        //
        public ICollection<ReservaEquipamentos> reservaEquipamentos1 { get; set; }
        
    }
}
