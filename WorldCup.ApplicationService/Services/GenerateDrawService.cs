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
        private readonly ITeamPlacementService _teamPlacementService;
        public GenerateDrawService(WorldCupDbUoW worldCupDbUoW, ITeamPlacementService teamPlacementService)
        {
            _dbUoW = worldCupDbUoW ?? throw new ArgumentNullException(nameof(worldCupDbUoW));
            _teamPlacementService = teamPlacementService ?? throw new ArgumentNullException(nameof(_teamPlacementService));
            
        }

        public async Task<DrawResult> DrawGroups(int groupCount, string firstName, string surname)
        {
            DrawResult drawResult = null!;
            var userEntity = new User()
            {
                FirstName = firstName,
                Surname = surname,
            };
            var currentDate = DateTime.Now;

            using (_dbUoW)
            {
                var groups = await _dbUoW.GroupsRepository.GetAsync();
                var groupsArray = groups
                    .Select(g => g.Id)
                    .ToArray();

                var teams = await _dbUoW.TeamsRepository.GetAsync();
                var teamsArray = teams
                    .Select(t => t.Id)
                    .ToArray();

                drawResult = _teamPlacementService.PlaceTeamsInGroups(teamsArray, groupsArray, groupCount);

                foreach(var group in drawResult.Groups)
                {
                    foreach(var teamId in group.TeamIds)
                    {
                        var newDraw = new Draw()
                        {
                            CreatedOn = currentDate,
                            User = userEntity,
                            GroupsCount = groupCount,
                            TeamId = teamId,
                            GroupId = group.Id
                        };

                        _dbUoW.DrawsRepository.Insert(newDraw);
                    }
                }

                await _dbUoW.SaveAsync();
            }
            
            return drawResult;
        }
    }
}