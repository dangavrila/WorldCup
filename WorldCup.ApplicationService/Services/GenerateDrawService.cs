using WorldCup.ApplicationService.Models;

namespace WorldCup.ApplicationService.Services
{
    public interface IGenerateDrawService
    {
        Task<DrawResult> GetDrawResult(int groupCount, string firstName, string surname);
    }

    public class GenerateDrawService : IGenerateDrawService
    {
        public Task<DrawResult> GetDrawResult(int groupCount, string firstName, string surname)
        {
            return null;
        }
    }
}