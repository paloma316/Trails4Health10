using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Trails4Healthy.Models;

namespace Trails4Healthy.Data
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CreateTrail> Trails { get; set; }
    }
}
