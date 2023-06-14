using FITQUEST.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FITQUEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly ILeaderBoardRepository _leaderboardRepository;

        public LeaderboardController(ILeaderBoardRepository leaderboardRepository)
        {
            _leaderboardRepository = leaderboardRepository;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_leaderboardRepository.GetAll());
        }
    }
}
