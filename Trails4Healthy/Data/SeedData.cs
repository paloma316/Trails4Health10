﻿using System;
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
            

           

            ////Turista Dados
            if (!dbContext.Turistas.Any())
            {
                dbContext.Turistas.AddRange(
                new LoginClass { Nome = "Afonso Costa", Morada = "Guarda", Numero_Telefone = "930886504", username = "afonsino", Pass = "banana" },
               new LoginClass { Nome = "Marta", Morada = "Aveiro", Numero_Telefone = "920819221", username = "martinha", Pass = "gostoPeixe1" },
                new LoginClass { Nome = "Zeca Ernesto", Morada = "Viseu", Numero_Telefone = "927349343", username = "ernestinho", Pass = "Ernestinho2" }
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
            if (!dbContext.Equipamento.Any())
            {
                dbContext.Equipamento.AddRange(
       new Equipamento { NomeEquipamento = "Chapéu", DescricaoEquipamento = "Acessorio para a proteção da cabeça", ValorUnidade = 2,Disponível=true },
       new Equipamento { NomeEquipamento = "Sapatos", DescricaoEquipamento = "Acessorio para a proteção dos pes", ValorUnidade = 10,  Disponível = true },
        new Equipamento { NomeEquipamento = "Mochila", DescricaoEquipamento = "Acessorio para guarda objetos pessoais", ValorUnidade = 2, Disponível = true },
         new Equipamento { NomeEquipamento = "Relógio", DescricaoEquipamento = "Acessorio que permite visualisar as horas", ValorUnidade = 2, Disponível = false },
          new Equipamento { NomeEquipamento = "Casaco", DescricaoEquipamento = "Acessorio para a proteção contra o frio", ValorUnidade = 2, Disponível = true },
         new Equipamento { NomeEquipamento = "Binóculos", DescricaoEquipamento = "Acessorio que permite observar de longe", ValorUnidade = 2, Disponível = false},
         new Equipamento { NomeEquipamento = "Óculos", DescricaoEquipamento = "Acessorio para a proteção contra o Sol", ValorUnidade = 2, Disponível = true }

       );

        dbContext.SaveChanges();
            }


            //   Professor professor1 = dbContext.Professor.SingleOrDefault(p => p.NIF == "236512378");
            Equipamento Eq1 = dbContext.Equipamento.SingleOrDefault(eq => eq.EquipamentoId == 1);
            Equipamento Eq2 = dbContext.Equipamento.SingleOrDefault(eq => eq.EquipamentoId == 2);
            ReservaEquipamentos Res1 = dbContext.ReservaEquipamentos.SingleOrDefault(r => r.ReservaId == 1);
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

