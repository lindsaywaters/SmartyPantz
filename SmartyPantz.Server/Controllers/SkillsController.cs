using Microsoft.AspNetCore.Mvc;
using SmartyPantz.Server.Models;
using SmartyPantz.Server.Models.Contracts;

namespace SmartyPantz.Server.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController(ISkillRepository dataRepository) : ControllerBase
    {
        private ISkillRepository _dataRepository = dataRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            var skills = await _dataRepository.GetAllAsync();
            return Ok(skills);
        }

        [HttpGet ("{id}", Name = "GetSkill")]
        public async Task<IActionResult> GetSkill(int id)
        {
            var skill = await _dataRepository.GetAsync(id);
            if (skill is null) 
            {
                return NotFound("Skill not found."); 
            }
            return Ok(skill);
        }
    }
}

