using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class Local
    {
        public int LocalizacaoID { get; set; }// chave primaria
        public string NomeLocalidade { get; set; }//
        public string Concelho{ get; set; }//
        public string Distrito{ get; set; }//
        public string Coordenadas { get; set; }// coordenada de gps do local
        public string Descricao { get; set; }// pequeno texto com informaçoes sobre o local
    }
}
