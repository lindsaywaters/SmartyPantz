using Microsoft.AspNetCore.Mvc;
using SmartyPantz.Server.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SmartyPantz.Server.Controllers
{
    [ApiController]
    [Route("api/userSkills")]
    public class UserSkillsController : ControllerBase
    {
        private readonly IUserSkillRepository _userSkillRepository;

        public UserSkillsController(IUserSkillRepository userSkillRepository)
        {
            _userSkillRepository = userSkillRepository;
        }

        [HttpGet("{userId}")]
        public IActionResult GetSkillsForUser(int userId)
        {
            var skills = _userSkillRepository.GetSkillsForUser(userId);
            if (skills == null || !skills.Any())
            {
                return NotFound();
            }

            return Ok(skills);
        }

        [HttpPost]
        public IActionResult AddSkillsToUser([FromBody] UserSkillsDto userSkillsDto)
        {
            if (userSkillsDto.SkillIds == null || !userSkillsDto.SkillIds.Any())
            {
                return BadRequest("Skill IDs cannot be empty");
            }

            _userSkillRepository.AddSkillsToUser(userSkillsDto.UserId, userSkillsDto.SkillIds);
            return Ok();
        }

        [HttpDelete("{userId}/{skillId}")]
        public IActionResult RemoveSkillFromUser(int userId, int skillId)
        {
            _userSkillRepository.RemoveSkillFromUser(userId, skillId);
            return NoContent();
        }

        public class UserSkillsDto
        {
            public int UserId { get; set; }
            public IEnumerable<int>? SkillIds { get; set; }
        }
    }
}
