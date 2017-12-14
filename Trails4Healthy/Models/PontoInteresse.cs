using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class PontoInteresse
    {

        public int PontoInteresseId { get; set; }  // chave primaria do ponto de interesse
        public string NomePontoInteresse { get; set; }

        public int CategoriaId { get; set; } //chave estrangera da tabela classe categoria
        public Categoria Categoria { get; set; }//parametro para ir busca a outra classe
        
        public int LocalizacaoId { get; set; }//chave estrangeira da classe local para saber onde se encontra
        public Local Local { get; set; }

        public string Descricao { get; set; } //pequeno texto em que descreve o ponto de interesse e o que esta a sua volta

    }
}
