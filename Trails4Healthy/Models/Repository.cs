using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Trails4Healthy.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Repository
    {
        private static List<Trail> TrailCreated = new List<Trail>();

        public static void AddTrail(Trail trail)
        {
            TrailCreated.Add(trail);
        }

        public static IEnumerable<Trail> Trails
        {

            get
            {
                return TrailCreated;
            }
        }
    }
}
