using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.ApplicationService.Models;

namespace WorldCup.ApplicationService.Services
{
    public interface IQueryLeageGroupsService
    {
        Task<IEnumerable<PlacementResults>> GetDraws();
    }

    public class QueryLeageGroupsService : IQueryLeageGroupsService
    {
        public Task<IEnumerable<PlacementResults>> GetDraws()
        {
            return Task.FromResult(Enumerable.Empty<PlacementResults>());
        }
    }
}
