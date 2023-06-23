using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.ApplicationService.Models;

namespace WorldCup.ApplicationService.Services
{
    public interface ITeamPlacementService
    {
        DrawResult PlaceTeamsInGroups(int[] teamIds, int[] groupIds, int groupCount);
    }
    public class TeamPlacementService : ITeamPlacementService
    {
        public DrawResult PlaceTeamsInGroups(int[] teamIds, int[] groupIds, int groupCount)
        {
            int totalRounds = groupIds.Length / groupCount;
            int totalDraws = totalRounds * groupCount;

            return null;
        }
    }
}
