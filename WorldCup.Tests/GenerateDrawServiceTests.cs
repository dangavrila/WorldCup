using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WorldCup.ApplicationService.Services;
using WorldCup.DataAccess.Repositories;

namespace WorldCup.Tests
{
    internal class GenerateDrawServiceTests
    {
        private readonly IGenerateDrawService SUT;
        private readonly Mock<WorldCupDbUoW> _dbUoWMock;
        public GenerateDrawServiceTests()
        {
            _dbUoWMock = new Mock<WorldCupDbUoW>();
            SUT = new GenerateDrawService(_dbUoWMock.Object);
        }

        [Test]
        public async Task FourGroupsTest()
        {
            var result = await SUT.DrawGroups(4, "First", "Last");

            Assert.IsNotNull(result);
        }
    }
}
