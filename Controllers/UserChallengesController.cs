using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FITQUEST.Models;
using FITQUEST.Repositories;

namespace FITQUEST.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class UserChallengesController : ControllerBase
    {
        private readonly IUserChallengesRepository _userChallengesRepository;

        public UserChallengesController(IUserChallengesRepository userChallengesRepository)
        {
            _userChallengesRepository = userChallengesRepository;
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            return Ok(_userChallengesRepository.GetById(id));
        }

        [HttpPost]

        public IActionResult Add(UserChallenges userChallenges)
        {
            var newUserChallenge = _userChallengesRepository.Add(userChallenges);
            return Ok(new
            {
                Message = "Added to User's Challenges",
                UserChallenges = newUserChallenge
            });
        }

        [HttpPut]

        public IActionResult Update(UserChallenges userChallenges)
        {
            _userChallengesRepository.Update(userChallenges);
            return NoContent();
        }

         [HttpDelete]
         public IActionResult Delete(int id) 
         { 
            _userChallengesRepository?.Delete(id);
             return NoContent();
         }

    }

