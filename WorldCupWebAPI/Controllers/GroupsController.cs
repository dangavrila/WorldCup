using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorldCup.WebAPI.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly ILogger<GroupsController> _logger;

        public GroupsController(ILogger<GroupsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "DrawGroups")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateDraws(int groupCount, string name, string surname)
        {
            return NoContent();
        }
    }
}
