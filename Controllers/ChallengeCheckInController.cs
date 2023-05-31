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

        [HttpGet("{id}")]

        public IActionResult GetAllByUserId(int id)
        {
           return Ok(_challengeCheckInRepository.GetAllByUserId(id));
        }

        [HttpPost]
        public IActionResult Add(ChallengeCheckIn challengeCheckIn) 
        {
            var newChallengeCheckin = _challengeCheckInRepository.Add(challengeCheckIn);
            return Ok(new
            {
                message = "Created",
                challengeCheckIn = newChallengeCheckin
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(ChallengeCheckIn challengeCheckIn, int id)
        {
            _challengeCheckInRepository.Update(challengeCheckIn, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _challengeCheckInRepository.Delete(id);
            return NoContent();
        }
    }
}
