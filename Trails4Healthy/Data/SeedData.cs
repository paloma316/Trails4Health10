using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Healthy.Models;

namespace Trails4Healthy.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            TrailsDbContext dbContext = (TrailsDbContext)serviceProvider.GetService(typeof(TrailsDbContext));
            if (!dbContext.Trails.Any())
            {
                EnsureTrailsPopulated(dbContext);
            }
            dbContext.SaveChanges();
        }

        private static void EnsureTrailsPopulated(TrailsDbContext dbContext) { 
            dbContext.Difficulties.AddRange(
                new Difficulty { Name = "Facil" },
                new Difficulty { Name = "Media" },
                new Difficulty { Name = "Dificil" }

                );

            dbContext.Trails.AddRange(
                 new Trail { Name = "Trail 1", Available = true, DifficultyId = 4, Distance = "275 " },
                 new Trail { Name = "Trail 2", Available = false, DifficultyId = 2, Distance = "1000 " }


            );

            //Turista Dados
            dbContext.Turistas.AddRange(
                new LoginClass { Nome="Afonso Costa",Morada="Guarda",Numero_Telefone="930886504",username="afonsino",pass="banana"},
                new LoginClass { Nome="Marta",Morada="Aveiro",Numero_Telefone="920819221",username="martinha",pass="gostoPeixe1"},
                new LoginClass { Nome="Zeca Ernesto",Morada="Viseu",Numero_Telefone="927349343",username="ernestinho",pass="Ernestinho2"}
                );

            //Reserva Equipamentos



            //Equipamentos
            dbContext.Equipamento.AddRange(
                new Equipamento { NomeEquipamento="bola",DescricaoEquipamento="material usado para diversão",ValorUnidade=2},
                new Equipamento { NomeEquipamento="tenis",DescricaoEquipamento="acessorio para a proteção dos pes",ValorUnidade=10}
                );

            dbContext.Estados.AddRange(
                new Estado { NomeEstado="Aberto",Descricao="valor gerado por defeito"},
                  new Estado { NomeEstado = "Fechado", Descricao = "valor gerado por defeito" }
                );


        }
    }
    
}

