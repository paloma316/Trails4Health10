using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class PontoInteresse
    {
<<<<<<< HEAD
        public int Id_PontoInteresse { get; set; }  // chave primaria do ponto de interesse
        public string Nome { get; set; }  // nome do campo de interesse
        public int Id_Categoria { get; set; } //chave estrangera da tabela classe categoria
        public int Coordenadas { get; set; } //coordenada da localisação do ponte de interesse e vai ter que ter validação
        public string Descricao { get; set; } //pequeno texto em que descreve o ponto de interesse e o que esta a sua volta
=======
        public int IDPontoInteresse { get; set; } // chave primaria da classse ponto de interesse
        public string nomePontoInteresse { get; set; }
        public int IDCategoria { get; set; }// chave estragera da classe categorias
        public int IDLocalização { get; set; }//chave estrangeira da classe local para saber onde se encontra
        public string descricao { get; set; }//pequeno texto com algomas informações sobre o ponto de interesse
>>>>>>> 90f07b9467ff8f58174253840081560ae60f7ff2
    }
}
