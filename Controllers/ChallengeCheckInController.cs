using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FITQUEST.Models;
using FITQUEST.Repositories;

namespace FITQUEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeCheckInController : ControllerBase
    {
        private readonly IChallengeCheckInRepository _challengeCheckInRepository;

        public ChallengeCheckInController(IChallengeCheckInRepository challenegeCheckInRepository)
        {
            _challengeCheckInRepository = challenegeCheckInRepository;
        }

        [HttpGet("By User Id")]

        public IActionResult GetAllByUserId(User users, int id)
        {
           return Ok(_challengeCheckInRepository.GetAllByUserId(id));
        }
    }
}
