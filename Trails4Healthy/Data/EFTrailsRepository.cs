using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Healthy.Data;

namespace Trails4Healthy.Models
{
    public class EFTrailsRepository : ITrailsRepository
    {
        private TrailsDbContext dbContext;

        public EFTrailsRepository(TrailsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }




        public IEnumerable<Trail> Trails => dbContext.Trails;

    }
}