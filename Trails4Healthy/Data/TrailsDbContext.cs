using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Healthy.Models;

namespace Trails4Healthy.Data
{
    public class TrailsDbContext : DbContext
    {
        public TrailsDbContext(DbContextOptions<TrailsDbContext> options) : base(options) { }

        public DbSet<Trail> Trails { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Chaves estrangeiras de Trails
            modelBuilder.Entity<Trail>()
                .HasOne(trail => trail.Difficulty)
                .WithMany(difficulty => difficulty.Trails)
                .HasForeignKey(trail => trail.DifficultyID);

            
        }
    }
}
