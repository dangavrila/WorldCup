using WorldCup.ApplicationService.Models;
using WorldCup.DataAccess.Entities;
using WorldCup.DataAccess.Repositories;

namespace WorldCup.ApplicationService.Services
{
    public interface IGenerateDrawService
    {
        Task<DrawGroupsResponse> DrawGroups(int groupCount, string firstName, string surname);
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

        public async Task<DrawGroupsResponse> DrawGroups(int groupCount, string firstName, string surname)
        {
            DrawGroupsResponse drawGroupsResponse = null!;
            var userEntity = new User()
            {
                FirstName = firstName,
                Surname = surname,
            };
            var currentDate = DateTime.Now;

            using (_dbUoW)
            {
                var groups = await _dbUoW.GroupsRepository.GetAsync();
                var groupsDic = groups
                    .Take(groupCount)
                    .ToDictionary(g => g.Id);

                var teams = await _dbUoW.TeamsRepository.GetAsync();
                var teamsDic = teams
                    .ToDictionary(t => t.Id);

                var placementResults = _teamPlacementService.PlaceTeamsInGroups(teamsDic.Keys.ToArray(), groupsDic.Keys.ToArray(), groupCount);

                drawGroupsResponse = new DrawGroupsResponse();

                foreach (var groupId in placementResults.Groups.Keys)
                {
                    var groupModel = new GroupModel()
                    {
                        GroupName = groupsDic[groupId].Name
                    };

                    foreach(var teamId in placementResults.Groups[groupId].TeamIds)
                    {
                        groupModel.Teams.Add(new Name(teamsDic[teamId].Name));
                        var newDraw = new Draw()
                        {
                            CreatedOn = currentDate,
                            User = userEntity,
                            GroupsCount = groupCount,
                            TeamId = teamId,
                            GroupId = groupId
                        };

                        _dbUoW.DrawsRepository.Insert(newDraw);
                    }

                    drawGroupsResponse.Groups.Add(groupModel);
                }

                await _dbUoW.SaveAsync();
            }
            
            return drawGroupsResponse;
        }
    }
}