using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }// chave primaria
        public string NomeCategoria { get; set; }//
        public string Estacao { get; set; }// melhor estação estação do ano em que a categoria se aplica 
        public string Descricao { get; set; }//pequeno texto com ou sem detalhes sobre a descrição da categorio
    }
}
