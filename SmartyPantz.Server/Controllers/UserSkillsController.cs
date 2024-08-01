using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartyPantz.Server.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SmartyPantz.Server.Controllers
{
    [ApiController]
    [Route("api/userSkills")]
    public class UserSkillsController : ControllerBase
    {
        private readonly IUserSkillRepository _context;

        public UserSkillsController(IUserSkillRepository userSkillRepository)
        {
            _context = userSkillRepository;
        }

        [HttpGet("{userId}")]
        public IActionResult GetSkillsForUser(int userId)
        {
            var skills = _context.GetSkillsForUser(userId);
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

            _context.AddSkillsToUser(userSkillsDto.UserId, userSkillsDto.SkillIds);
            return Ok();
        }

        [HttpDelete("{userId}/{skillId}")]
        public IActionResult RemoveSkillFromUser(int userId, int skillId)
        {
            _context.RemoveSkillFromUser(userId, skillId);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public IActionResult RemoveSkillsFromUser(int userId, [FromBody] IEnumerable<int> skillIds)
        {
            if (skillIds == null || !skillIds.Any())
            {
                return BadRequest("Skill IDs cannot be empty");
            }

            _context.RemoveSkillsFromUser(userId, skillIds);
            return NoContent();
        }

        [HttpPut("{userId}/markComplete")]
        public async Task<IActionResult> MarkSkillComplete(int userId, [FromBody] MarkSkillCompleteRequest request)
        {
            var userSkill = await _context.GetUserSkillAsync(userId, request.SkillId);

            if (userSkill == null)
            {
                return NotFound();
            }

            userSkill.IsNeeded = false;
            await _context.UpdateUserSkillAsync(userSkill);

            return NoContent();
        }



        public class MarkSkillCompleteRequest
        {
            public int SkillId { get; set; }
        }


        public class UserSkillsDto
        {
            public int UserId { get; set; }
            public IEnumerable<int>? SkillIds { get; set; }
        }
    }
}
