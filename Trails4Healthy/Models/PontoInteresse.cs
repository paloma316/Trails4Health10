using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class PontoInteresse
    {
        public int Id_PontoInteresse { get; set; }  // chave primaria do ponto de interesse
        public string Nome { get; set; }  // nome do campo de interesse
        public int Id_Categoria { get; set; } //chave estrangera da tabela classe categoria
        public int Coordenadas { get; set; } //coordenada da localisação do ponte de interesse e vai ter que ter validação
        public string Descricao { get; set; } //pequeno texto em que descreve o ponto de interesse e o que esta a sua volta
    }
}
