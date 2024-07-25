using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartyPantz.Server.Models.Contracts;

namespace SmartyPantz.Server.Controllers
{
    [ApiController]
    [Route("api/resources")]
    public class ResourceController(IResourceRepository _dataRepository) : ControllerBase
    {
        private IResourceRepository _dataRepository = _dataRepository;


        [HttpGet]
        public async Task<IActionResult> GetAllResources() 
        {
            var resources = await _dataRepository.GetAllAsync();
            return Ok(resources);
        }

        [HttpGet]

        [HttpGet("grouped-by-skill")]
        public async Task<IActionResult> GetResourcesGroupedBySkill()
        {
            var resourcesGroupedBySkill = await _dataRepository.GetAllResourcesGroupedBySkillAsync();
            return Ok(resourcesGroupedBySkill);
        }

    }
}
