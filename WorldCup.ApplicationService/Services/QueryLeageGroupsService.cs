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
