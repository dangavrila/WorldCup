using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldCup.ApplicationService.Models;
using WorldCup.ApplicationService.Services;
using WorldCup.WebAPI.Models;

namespace WorldCup.WebAPI.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly ILogger<GroupsController> _logger;
        private readonly IGenerateDrawService _drawService;
        private readonly IQueryLeageGroupsService _queryLeageGroupsService;

        public GroupsController(ILogger<GroupsController> logger,
            IGenerateDrawService drawService,
            IQueryLeageGroupsService queryLeageGroupsService)
        {
            _logger = logger;
            _drawService = drawService ?? throw new ArgumentNullException(nameof(drawService));
            _queryLeageGroupsService = queryLeageGroupsService ?? throw new ArgumentNullException(nameof(queryLeageGroupsService));
        }

        [HttpPost(Name = "DrawGroups")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> DrawGroups(DrawGroupsRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(request.GroupCount != 4 || request.GroupCount != 8)
                return UnprocessableEntity();

            if(request.User == null)
                return UnprocessableEntity();

            var drawResult = await _drawService.DrawGroups(request.GroupCount, request.User.FirstName, request.User.Surname);

            return Created("/groups", drawResult);
        }

        [HttpGet(Name = "GetLeagueGroups")]
        [ProducesResponseType(typeof(IEnumerable<PlacementResults>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetGroups()
        {
            var results = await _queryLeageGroupsService.GetDraws();
            if (results == null || !results.Any())
                return NoContent();

            return Ok(results);
        }
    }
}
