using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Trails4Healthy.Models
{
    public interface ITrailsRepository
    {
        IEnumerable<Trail> Trails { get; }
    }
}

