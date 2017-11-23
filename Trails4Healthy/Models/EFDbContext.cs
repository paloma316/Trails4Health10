using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class EFDbContext
    {
        private ApplicationDbContext context;
        public EFDbContext(ApplicationDbContext context)
        {
            this.context = context;
        }
       // public IEnumerable<Equipamento> Equipamentos => context.Equipamentos;
        public IEnumerable<Empresa> Empresas => context.Empresa;
      //  public IEnumerable<Turista> Turistas => context.Turistas;


    }
}
