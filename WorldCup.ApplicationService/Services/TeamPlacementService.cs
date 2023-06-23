using WorldCup.ApplicationService.Models;

namespace WorldCup.ApplicationService.Services
{
    public interface ITeamPlacementService
    {
        PlacementResults PlaceTeamsInGroups(int[] teamIds, int[] groupIds, int groupCount);
    }
    public class TeamPlacementService : ITeamPlacementService
    {
        public PlacementResults PlaceTeamsInGroups(int[] teamIds, int[] groupIds, int groupCount)
        {
            int totalRounds = teamIds.Length / groupCount;
            int totalDraws = 0;

            PlacementResults drawResult = new PlacementResults(groupIds);

            for (int i = 0; i < totalRounds; i++)
            {
                for (int j = 0; j < groupCount; j++)
                {
                    var teamId = teamIds[totalDraws++];
                    var currentGroup = drawResult.Groups[j + 1];
                    currentGroup.TeamIds.Add(teamId);
                }
            }

            drawResult.TotalDraws = totalDraws;

            return drawResult;
        }
    }
}
