using Microsoft.EntityFrameworkCore;
using SmartyPantz.Server.Models.Contracts;

namespace SmartyPantz.Server.Models.DataRepository
{
    public class ResourceRepository(ApplicationContext context) : IResourceRepository
    {

    ApplicationContext _resourceContext = context;

     

        public async Task<IEnumerable<Resource>> GetAllAsync()
        {
            return await _resourceContext.Resources.ToListAsync<Resource>();
        }

        public async Task<Resource?> GetAsync(int id) => await _resourceContext.Resources.FindAsync(id);

        public async Task<IEnumerable<object>> GetAllResourcesGroupedBySkillAsync()
        {
            return await _resourceContext.Skills
                .Select(skill => new
                {
                    Skill = skill.Title,
                    Resources = _resourceContext.Resources
                        .Where(r => r.SkillId == skill.Id)
                        .Select(r => new
                        {
                            r.Type,
                            r.Name
                        })
                        .ToList()
                })
                .ToListAsync();
        }

    };
}
