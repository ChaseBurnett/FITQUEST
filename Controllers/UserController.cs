using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FITQUEST.Models;
using FITQUEST.Repositories;

namespace FITQUEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult AddUser(User userDetails)
        {
            return Ok(_userRepository.AddUser(userDetails));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_userRepository.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User userDetails)
        {
            if (id != userDetails.id)
            {
                return BadRequest();
            }

            _userRepository.UpdateUser(userDetails);
            return NoContent();
        }
    }
}
