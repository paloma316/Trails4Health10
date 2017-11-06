using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class Repositorio
    {

        private static List<LoginClass> guestRsponse = new List<LoginClass>();

        //dois métodos:
        //-
        //-
        public static void AddGuestResponse(LoginClass response)
        {
            guestRsponse.Add(response);
        }

        public static IEnumerable<LoginClass> Responses()
        {
            return guestRsponse;
        }
    }
}
