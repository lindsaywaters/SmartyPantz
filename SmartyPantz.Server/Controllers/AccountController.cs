using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SmartyPantz.Server.Models.Contracts;
using SmartyPantz.Server.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.Extensions.Logging;

namespace SmartyPantz.Server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings, ILogger<AccountController> logger)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings.Value;
            _logger = logger;
           
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
            
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
            };

            await _userRepository.AddUserAsync(user);

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            _logger.LogInformation("JWT Key: {Key}", _jwtSettings.Key);
            var user = await AuthenticateUserAsync(model.Username, model.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var token = GenerateJwtToken(user);

            return Ok(new { 
                Token = token,
                userId = user.Id
            });
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

        private string GenerateJwtToken(User user)
        {
            // Log the JWT key for debugging
            _logger.LogInformation("JWT Key: {Key}", _jwtSettings.Key);

            if (string.IsNullOrEmpty(_jwtSettings.Key))
            {
                throw new InvalidOperationException("JWT key is not configured.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private async Task<User?> AuthenticateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            // Check if user exists
            if (user == null)
            {
                return null;
            }

            // Check if the provided password matches the stored hash
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            return isPasswordValid ? user : null;
        }
    }



}
