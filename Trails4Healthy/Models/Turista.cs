using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class Turista
    {
        //Turista=Utilizador
        public int IdTurista{get;set;}
        public string NomeTurista { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Numero_Telefone { get; set; }
        public string Morada { get; set; }
    }
}
