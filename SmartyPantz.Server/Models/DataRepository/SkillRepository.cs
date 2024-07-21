using Microsoft.EntityFrameworkCore;
using SmartyPantz.Server.Models.Contracts;

namespace SmartyPantz.Server.Models.DataRepository
{
    public class SkillRepository (ApplicationContext context) : ISkillRepository
    {
         ApplicationContext _skillContext = context;

        public async Task AddAsync(Skill entity)
        {

            _skillContext.Skills.Add(entity);
            await _skillContext.SaveChangesAsync();
            
        }

        public async Task<Skill?> GetAsync(int id) => await _skillContext.Skills.FindAsync(id);
       
        public async Task DeleteAsync(Skill entity)
        {
            _skillContext.Skills.Remove(entity);
            await _skillContext.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            
           
            return await _skillContext.Skills.ToListAsync<Skill>();
        }

        public async Task UpdateAsync(Skill entityToUpdate, Skill entity)
        {
            entityToUpdate.Description = entity.Description;
            entityToUpdate.Title = entity.Title;
            entityToUpdate.IsChecked = entity.IsChecked;

            await _skillContext.SaveChangesAsync();
        }


    }
}
