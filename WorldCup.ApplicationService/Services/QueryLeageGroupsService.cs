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
        Task<IEnumerable<DrawResult>> GetDraws();
    }

    public class QueryLeageGroupsService : IQueryLeageGroupsService
    {
        public Task<IEnumerable<DrawResult>> GetDraws()
        {
            return Task.FromResult(Enumerable.Empty<DrawResult>());
        }
    }
}
