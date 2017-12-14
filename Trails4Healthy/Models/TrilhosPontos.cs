using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class TrilhosPontos
    {
        public int PontoInteresseId { get; set; } // chave concatenada ponto de interesse
        public PontoInteresse PontoInteresse { get; set; }

        public int TrailID { get; set; }// chave concatenada trilho
        public Trail Trail { get; set; }
    }
}
