using WorldCup.ApplicationService.Services;
using WorldCup.DataAccess.Entities;

namespace WorldCup.Tests
{
    internal class TeamPlacementServiceTests
    {
        private readonly ITeamPlacementService SUT;
        private IEnumerable<DataAccess.Entities.Group> _groups;
        private IEnumerable<Team> _teams;
        public TeamPlacementServiceTests()
        {
            SUT = new TeamPlacementService();
        }

        [SetUp]
        public void Init()
        {
            _groups = new List<DataAccess.Entities.Group>() {
                new DataAccess.Entities.Group() { Id = 1, Name = "A"},
                new DataAccess.Entities.Group() { Id = 1, Name = "B"},
                new DataAccess.Entities.Group() { Id = 1, Name = "C"},
                new DataAccess.Entities.Group() { Id = 1, Name = "D"},
                new DataAccess.Entities.Group() { Id = 1, Name = "E"},
                new DataAccess.Entities.Group() { Id = 1, Name = "F"},
                new DataAccess.Entities.Group() { Id = 1, Name = "G"},
                new DataAccess.Entities.Group() { Id = 1, Name = "H"}};

            _teams = new List<Team>() {
                new Team() { Id = 1, Name = "Adesso Berlin", CountryId = 1 },
                new Team() { Id = 2, Name = "Adesso Frankfurt", CountryId = 1 },
                new Team() { Id = 3, Name = "Adesso Munich", CountryId = 1 },
                new Team() { Id = 4, Name = "Adesso Dormund", CountryId = 1 },
                new Team() { Id = 5, Name = "Adesso Istanbul", CountryId = 2 },
                new Team() { Id = 6, Name = "Adesso Ankara", CountryId = 2 },
                new Team() { Id = 7, Name = "Adesso Izmir", CountryId = 2 },
                new Team() { Id = 8, Name = "Adesso Antalya", CountryId = 2 },
                new Team() { Id = 9, Name = "Adesso Paris", CountryId = 3 },
                new Team() { Id = 10, Name = "Adesso Marsilya", CountryId = 3 },
                new Team() { Id = 11, Name = "Adesso Nice", CountryId = 3 },
                new Team() { Id = 12, Name = "Adesso Lyon", CountryId = 3 },
                new Team() { Id = 13, Name = "Adesso Amsterdam", CountryId = 4 },
                new Team() { Id = 14, Name = "Adesso Rotterdam", CountryId = 4 },
                new Team() { Id = 15, Name = "Adesso Lahey", CountryId = 4 },
                new Team() { Id = 16, Name = "Adesso Eindhoven", CountryId = 4 },
                new Team() { Id = 17, Name = "Adesso Lisbon", CountryId = 5 },
                new Team() { Id = 18, Name = "Adesso Porto", CountryId = 5 },
                new Team() { Id = 19, Name = "Adesso Braga", CountryId = 5 },
                new Team() { Id = 20, Name = "Adesso Coimbra", CountryId = 5 },
                new Team() { Id = 21, Name = "Adesso Roma", CountryId = 6 },
                new Team() { Id = 22, Name = "Adesso Milano", CountryId = 6 },
                new Team() { Id = 23, Name = "Adesso Venedik", CountryId = 6 },
                new Team() { Id = 24, Name = "Adesso Napoli", CountryId = 6 },
                new Team() { Id = 25, Name = "Adesso Sevilla", CountryId = 7 },
                new Team() { Id = 26, Name = "Adesso Madrid", CountryId = 7 },
                new Team() { Id = 27, Name = "Adesso Barcelona", CountryId = 7 },
                new Team() { Id = 28, Name = "Adesso Granada", CountryId = 7 },
                new Team() { Id = 29, Name = "Adesso Brussel", CountryId = 8 },
                new Team() { Id = 30, Name = "Adesso Bruges", CountryId = 8 },
                new Team() { Id = 31, Name = "Adesso Gent", CountryId = 8 },
                new Team() { Id = 32, Name = "Adesso Antwerp", CountryId = 8 }};
        }

        [Test]
        public void FourGroupsTest()
        {
            var result = SUT.PlaceTeamsInGroups(_teams.Select(x => x.Id).ToArray(), _groups.Select(x => x.Id).ToArray(), 4);

            Assert.IsNotNull(result);
        }
    }
}
