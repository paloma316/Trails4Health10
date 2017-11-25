using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Trails4Healthy.Models;

namespace Trails4Healthy.Data
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class EFTrailsRepository:Repository
    {
        private ApplicationDbContext context;
        public EFTrailsRepository(ApplicationDbContext context) { this.context = context; }
        public IEnumerable<CreateTrail> Trails => context.Trails;
    }
}
