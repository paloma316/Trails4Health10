﻿using System;
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
        private static List<CreateTrail> TrailCreated = new List<CreateTrail>();

        public static void AddCreateTrail(CreateTrail Trails)
        {
            TrailCreated.Add(Trails);
        }

        public static IEnumerable<CreateTrail> Trails
        {

            get
            {
                return TrailCreated;
            }
        }
    }
}
