using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Healthy.Models;

namespace Trails4Healthy.Data
{
    public class DadosEquipamento:InterfaceEquipamento
    {
        public IEnumerable<Equipamento> Equipamentos => new List<Equipamento> {
new Equipamento { NomeEquipamento= "Relogio", DescricaoEquipamento="Aparelho que funciona a pilhas e permite visualisar as horas"  ,ValorUnidade= 25 ,},
new Equipamento { NomeEquipamento = "Ténis",DescricaoEquipamento="Acessório que permite proteger os pés na sua deslocação", ValorUnidade = 179 ,},
new Equipamento { NomeEquipamento = "Bussóla GPS",DescricaoEquipamento="Aparelho que informa a localização", ValorUnidade = 95 ,}
};
        /* 
               public IEnumerable<Empresa> Empresas => new List<Empresa>
               {
                   new Empresa{NomeEmpresa="Zimex Sport",Contactos="939503504"},
                     new Empresa{NomeEmpresa="Sport Patner",Contactos="939503599"},
                       new Empresa{NomeEmpresa="SportZone",Contactos="939503902"}
               };

             public IEnumerable<Turista> Turistas => new List<Turista>
               {
                   new Turista{NomeTurista="Carlos Amado",Username="Carlinhos",Password="Mauzinho",Numero_Telefone="929560944"},
                    new Turista{NomeTurista="Jose Bastos",Username="zezinhob",Password="fofinho34",Numero_Telefone="929560864"},
                     new Turista{NomeTurista="Ana Carla Fonseca",Username="Anitinhas",Password="DificilFazer2",Numero_Telefone="969110944"}
               };

               public IEnumerable<Dificuldade> Dificuldades => new List<Dificuldade> {
                   new Dificuldade{NomeDificuldade="Pouco Dificil",Observacao=""},
                      new Dificuldade{NomeDificuldade="Razoavel",Observacao=""},
                         new Dificuldade{NomeDificuldade="Muito Dificil",Observacao=""}
               };*/
    }
}
