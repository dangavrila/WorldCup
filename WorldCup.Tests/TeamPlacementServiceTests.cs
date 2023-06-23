using WorldCup.ApplicationService.Services;

namespace WorldCup.Tests
{
    internal class TeamPlacementServiceTests
    {
        private readonly ITeamPlacementService SUT;
        private int[] _groups;
        private int[] _teams;
        public TeamPlacementServiceTests()
        {
            SUT = new TeamPlacementService();
        }

        [SetUp]
        public void Init()
        {
            _groups = Enumerable.Range(1, 8).ToArray();

            _teams = Enumerable.Range(1, 32).ToArray();
        }

        [Test]
        public void FourGroupsTest()
        {
            // Arrange
            int groupCount = 4;

            // Act
            var result = SUT.PlaceTeamsInGroups(_teams, _groups.Take(groupCount).ToArray(), groupCount);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.TotalDraws, Is.EqualTo(result.Groups.Sum(g => g.Value.TeamIds.Count)));
            foreach(var rg in result.Groups.Keys)
            {
                var teamsInGroup = result.Groups[rg].TeamIds;
                Assert.That(teamsInGroup.Distinct().Count(), Is.EqualTo(teamsInGroup.Count));
            }
        }

        [Test]
        public void EightGroupsTest()
        {
            // Arrange
            int groupCount = 8;

            // Act
            var result = SUT.PlaceTeamsInGroups(_teams, _groups.Take(groupCount).ToArray(), groupCount);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.TotalDraws, Is.EqualTo(result.Groups.Sum(g => g.Value.TeamIds.Count)));
            foreach (var rg in result.Groups.Keys)
            {
                var teamsInGroup = result.Groups[rg].TeamIds;
                Assert.That(teamsInGroup.Distinct().Count(), Is.EqualTo(teamsInGroup.Count));
            }
        }
    }
}
