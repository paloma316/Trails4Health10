using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class Categorias
    {
        public int IDCategoria { get; set; }// chave primaria
        public string nomeCategoria { get; set; }//
        public string estaca { get; set; }// melhor estação estação do ano em que a categoria se aplica 
        public string descricao { get; set; }//pequeno texto com ou sem detalhes sobre a descrição da categorio
    }
}
