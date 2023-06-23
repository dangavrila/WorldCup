using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.ApplicationService.Services;

namespace WorldCup.Tests
{
    internal class GenerateDrawServiceTests
    {
        private readonly IGenerateDrawService SUT;

        public GenerateDrawServiceTests()
        {
            SUT = new GenerateDrawService();
        }

        [Test]
        public async Task FourGroupsTest()
        {
            var result = await SUT.DrawGroups(4, "First", "Last");

            Assert.IsNotNull(result);
        }
    }
}
