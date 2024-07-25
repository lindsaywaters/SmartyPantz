namespace SmartyPantz.Server.Models.Contracts
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetAllAsync();
        Task<Skill?> GetAsync(int id);
        Task AddAsync(Skill entity);
   
    }
}
