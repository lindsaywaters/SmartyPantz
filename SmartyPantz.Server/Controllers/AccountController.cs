using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SmartyPantz.Server.Models.Contracts;
using SmartyPantz.Server.Models;
using BCrypt.Net;

namespace SmartyPantz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            Console.WriteLine("recieved request");
            if (model == null)
            {
                return BadRequest("Model is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _userRepository.UserExistsAsync(model.Username, model.Email))
            {
                return BadRequest("Username or email already taken.");
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                ChildsName = model.ChildsName,
                ChildsAge = model.ChildsAge,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
            };

            await _userRepository.AddUserAsync(user);

            return Ok("User registered successfully.");
        }
    }
}
