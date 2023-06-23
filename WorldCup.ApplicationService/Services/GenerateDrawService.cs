using WorldCup.ApplicationService.Models;
using WorldCup.DataAccess.Entities;
using WorldCup.DataAccess.Repositories;

namespace WorldCup.ApplicationService.Services
{
    public interface IGenerateDrawService
    {
        Task<DrawResult> DrawGroups(int groupCount, string firstName, string surname);
    }

    public class GenerateDrawService : IGenerateDrawService
    {
        private readonly WorldCupDbUoW _dbUoW;
        public GenerateDrawService(WorldCupDbUoW worldCupDbUoW)
        {
            _dbUoW = worldCupDbUoW ?? throw new ArgumentNullException(nameof(worldCupDbUoW));
        }

        public async Task<DrawResult> DrawGroups(int groupCount, string firstName, string surname)
        {
            var groupsDic = new Dictionary<int, DataAccess.Entities.Group>();
            var userEntity = new User()
            {
                FirstName = firstName,
                Surname = surname,
            };
            var currentDate = DateTime.Now;

            using (_dbUoW)
            {
                var groups = await _dbUoW.GroupsRepository.GetAsync();
                groupsDic = groups.ToDictionary(s => s.Id);

                var teams = await _dbUoW.TeamsRepository.GetAsync();
                var teamsArray = teams.ToArray();

                int totalRounds = groupsDic.Count / groupCount;
                int totalDraws = totalRounds * groupCount;

                for (int i = 0; i < totalDraws; i++)
                {
                    var newDraw = new Draw()
                    {
                        CreatedOn = currentDate,
                        User = userEntity,
                        GroupsCount = groupCount,
                        GroupId = i + 1,
                    };

                    _dbUoW.DrawsRepository.Insert(newDraw);
                }

                await _dbUoW.SaveAsync();
            }
            
            //TODO: map Draw entity to DrawResult

            return new DrawResult();
        }
    }
}