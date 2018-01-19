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

            EnsureTrailsPopulated(dbContext);

        }


        private static void EnsureTrailsPopulated(TrailsDbContext dbContext)
        {
           

            if (!dbContext.Difficulties.Any())
            {

                dbContext.Difficulties.AddRange(
                new Difficulty { Name = "Facil" },
                new Difficulty { Name = "Media" },
                new Difficulty { Name = "Dificil" }

                );
                dbContext.SaveChanges();
            }
            

           


            //Trilho
            if (!dbContext.Trails.Any())
            {

                var dificuldadeFacil = dbContext.Difficulties.SingleOrDefault(d => d.Name == "Facil");
                var dificuldadeMedia = dbContext.Difficulties.SingleOrDefault(d => d.Name == "Dificil");

                dbContext.Trails.AddRange(
                     new Trail { Name = "Trail 1", Available = true, Difficulty = dificuldadeFacil, Distance = "275" },
                     new Trail { Name = "Trail 2", Available = false, Difficulty = dificuldadeMedia, Distance = "1000" }
                     

                );
                dbContext.SaveChanges();
            }
        
            //Linha Equipamento
            /*
            if (!dbContext.Linha_Equipamento.Any())
            {
                dbContext.Linha_Equipamento.AddRange(
     //  new Equipamento { NomeEquipamento = "Chapéu", DescricaoEquipamento = "Acessorio para a proteção da cabeça", ValorUnidade = 2, Disponível = true },
     new Linha_Equipamento_Reserva { EquipamentoId=Eq1.EquipamentoId,Quantidade=1,ReservaId=Res1.ReservaId},
     new Linha_Equipamento_Reserva { EquipamentoId = Eq2.EquipamentoId, Quantidade=2, ReservaId = Res1.ReservaId ,}


       );

                dbContext.SaveChanges();
            }
            /*
       //Reserva Equipamentos

       //Empresa
       dbContext.AddRange(
           new Empresa { NomeEmpresa = "Zone",Contactos="928340188", EmpresaId=1}
           );


       //Equipamentos

    dbContext.Equipamento.AddRange(
        new Equipamento { NomeEquipamento="bola",DescricaoEquipamento="material usado para diversão",ValorUnidade=2,},
        new Equipamento { NomeEquipamento="tenis",DescricaoEquipamento="acessorio para a proteção dos pes",ValorUnidade=10}
        );

dbContext.Estados.AddRange(
       new Estado { NomeEstado="Aberto",Descricao="valor gerado por defeito"},
         new Estado { NomeEstado = "Fechado", Descricao = "Em construcao" }
       );*/


        }
    }

}

