using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Trails4Healthy.Models
{
    
    public class Difficulty
    {
        public int DifficultyID { get; set; }
        public string Name { get; set; }
        public ICollection<Trail> Trails { get; set; }
    }
}
