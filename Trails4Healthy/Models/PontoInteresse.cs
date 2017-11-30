using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class PontoInteresse
    {
        public int IDPontoInteresse { get; set; } // chave primaria da classse ponto de interesse
        public string nomePontoInteresse { get; set; }
        public int IDCategoria { get; set; }// chave estragera da classe categorias
        public int IDLocalização { get; set; }//chave estrangeira da classe local para saber onde se encontra
        public string descricao { get; set; }//pequeno texto com algomas informações sobre o ponto de interesse
    }
}
