using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Healthy.Models;

namespace Trails4Healthy.Data
{/*
    public class SeedData
    {
        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            TrailsDbContext dbContext = (TrailsDbContext)serviceProvider.GetService(typeof(TrailsDbContext));
            if (!dbContext.Trails.Any())
            {
                EnsureTrailsPopulated(dbContext);
            }
            dbContext.SaveChanges();
        }

        private static void EnsureTrailsPopulated(TrailsDbContext dbContext) { 
            dbContext.Difficulties.AddRange(
                new Difficulty { Name = "Facil" },
                new Difficulty { Name = "Media" },
                new Difficulty { Name = "Dificil" }

                );

            dbContext.Trails.AddRange(
                 new Trail { Name = "Trail 1", Available = true, DifficultyId = 4, Distance = "275 " },
                 new Trail { Name = "Trail 2", Available = false, DifficultyId = 2, Distance = "1000 " }


            );
        }
    }
    */
}

