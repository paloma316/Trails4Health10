using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class Equipamento

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipamentoId { get; set; }
        // public int EmpresaId { get; set; }
        public string NomeEquipamento { get; set; }
        public int QuantidadeEquip { get; set; }

        public string DescricaoEquipamento { get; set; }
        public decimal ValorUnidade { get; set; }
     
       
        public Boolean Disponível { get; set; }
      //  public string  imagem { get; set; } 


        public ICollection<Linha_Equipamento_Reserva> Linhas { get; set; }
        public Empresa Empresas { get; set; }
    }
}
