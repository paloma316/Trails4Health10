using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Healthy.Models;

namespace Trails4Healthy.Data
{
    public class DadosEmpresa
    {
        /*public static void EnsurePopulated(IServiceProvider appServices) {
ApplicationDbContext context = (ApplicationDbContext) appServices.GetService(typeof(ApplicationDbContext));
if (context.Products.Any()) return;
context.Products.AddRange(
new Product { Name = "Kayak", Description = "A boat for one person", Category = "Watersports", Price = 275},
new Product { Name = "Lifejacket", Description = "Protective and fashionable", Category = "Watersports", Price = 48.95m},
new Product { Name = "Soccer Ball", Description = "FIFA-approved size and weight", Category = "Soccer", Price = 19.50m},
new Product { Name = "Corner Flags", Description = "Give your playing field a professional touch", Category = "Soccer", Price = 34.95m},
new Product { Name = "Stadium", Description = "Flat-packed 35,000-seat stadium", Category = "Soccer", Price = 79500},
new Product { Name = "Thinking Cap", Description = "Improve brain efficiency by 75%", Category = "Chess", Price = 16},
new Product { Name = "Unsteady Chair", Description = "Secretly give your opponent a disadvantage", Category = "Chess", Price = 29.95m},
new Product { Name = "Human Chess Board", Description = "A fun game for the family", Category = "Chess", Price = 75},
new Product { Name = "Bling-Bling King", Description = "Gold-plated, diamond-studded King", Category = "Chess", Price = 1200}
);
context.SaveChanges();
}*/



        /* IEnumerable<Empresa> InterfaceEmpresa.Empresas => new List<Empresa>
                {
                    new Empresa{NomeEmpresa="Zimex Sport",Contactos="939503504"},
                      new Empresa{NomeEmpresa="Sport Patner",Contactos="939503599"},
                        new Empresa{NomeEmpresa="SportZone",Contactos="939503902"}
                };
                */
        public static void EnsurePopulated(IServiceProvider appServices)
        {
            ApplicationDbContext context = (ApplicationDbContext)appServices.GetService(typeof(ApplicationDbContext));
            if (context.Empresa.Any()) return;
            context.Empresa.AddRange(
                new Empresa { NomeEmpresa = "Zimex Sport", Contactos = "939503504" },
                new Empresa { NomeEmpresa = "Sport Patner", Contactos = "939503599" },
                new Empresa { NomeEmpresa = "SportZone", Contactos = "939503902" }
                );

            context.SaveChanges();
        }
     

    }

}
