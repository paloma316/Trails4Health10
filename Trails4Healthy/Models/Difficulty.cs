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
    
    public class Difficulty
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DifficultyId { get; set; }
        public string Name { get; set; }
        public ICollection<Trail> Trails { get; set; }
         
    }
   
    }
