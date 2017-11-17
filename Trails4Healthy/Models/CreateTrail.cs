using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Trails4Healthy.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CreateTrail
    {
        
        [Required(ErrorMessage = "Insira o ID")]
        public int TrailID { get; set; }

            [Required(ErrorMessage = "Insira o nome do trilho")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Insira a distancia")]

            public string Distance { get; set; }

        [Required(ErrorMessage = "Insira a dificuldade")]
        public string Difficulty { get; set; }


            [Required(ErrorMessage = "Diga se está disponivel o ano todo ")]
            public bool? Available { get; set; }


    }
}
