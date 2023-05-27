using FITQUEST.Repositories;
using FITQUEST.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FITQUEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallenegeRepository _challenegeRepository;

        public ChallengeController(IChallenegeRepository challenegeRepository)
        {
            _challenegeRepository = challenegeRepository;
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_challenegeRepository.GetAll());
        }

        [HttpGet("By Tier")]

        public IActionResult GetAllByTier(int tier) 
        {
            var challenge = _challenegeRepository.GetAllByTier(tier);
            if(challenge == null)
            {
                return NotFound();
            }
            return Ok(challenge);
        }
    }
}
