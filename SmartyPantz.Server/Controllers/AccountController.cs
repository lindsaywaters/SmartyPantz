using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SmartyPantz.Server.Models.Contracts;
using SmartyPantz.Server.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;

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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.GetUserByUsernameAsync(model.Username);

                if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                {
                    // Set session
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    return Ok("Login successful");
                }

                return Unauthorized("Invalid username or password");
            }

            return BadRequest(ModelState);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Ok("Logout successful");
        }

        [HttpGet("check-auth")]
        public IActionResult CheckAuth()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId != null)
            {
                return Ok("Authenticated");
            }

            return Unauthorized();
        }
    }
}
