using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class Local
    {
        public int IDLocalização { get; set; }// chave primaria
        public string nomeLocalidade { get; set; }//
        public string conselho{ get; set; }//
        public string distrito{ get; set; }//
        public int coordenadas { get; set; }// coordenada de gps do local
        public string descricao { get; set; }// pequeno texto com informaçoes sobre o local
    }
}
