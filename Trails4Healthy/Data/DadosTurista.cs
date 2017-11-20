using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Healthy.Models;

namespace Trails4Healthy.Data
{
    public class DadosTurista:InterfaceTurista
    {
        public IEnumerable<Turista> Turistas => new List<Turista>
               {
                   new Turista{NomeTurista="Carlos Amado",Username="Carlinhos",Password="Mauzinho",Numero_Telefone="929560944"},
                    new Turista{NomeTurista="Jose Bastos",Username="zezinhob",Password="fofinho34",Numero_Telefone="929560864"},
                     new Turista{NomeTurista="Ana Carla Fonseca",Username="Anitinhas",Password="DificilFazer2",Numero_Telefone="969110944"}
               };

    }
}
