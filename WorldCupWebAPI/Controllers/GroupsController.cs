using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public GroupsController(ILogger<GroupsController> logger, IGenerateDrawService drawService)
        {
            _logger = logger;
            _drawService = drawService ?? throw new ArgumentNullException(nameof(drawService));
        }

        [HttpPost(Name = "DrawGroups")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DrawGroups(DrawGroupsRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }
    }
}
