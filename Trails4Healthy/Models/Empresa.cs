using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }
        public string Contactos { get; set; }
        public string NomeEmpresa { get; set; }
    }
}
