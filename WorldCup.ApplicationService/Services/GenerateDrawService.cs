using WorldCup.ApplicationService.Models;

namespace WorldCup.ApplicationService.Services
{
    public interface IGenerateDrawService
    {
        Task<DrawResult> DrawGroups(int groupCount, string firstName, string surname);
    }

    public class GenerateDrawService : IGenerateDrawService
    {
        public Task<DrawResult> DrawGroups(int groupCount, string firstName, string surname)
        {
            return null;
        }
    }
}