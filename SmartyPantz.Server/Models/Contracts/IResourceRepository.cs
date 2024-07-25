namespace SmartyPantz.Server.Models.Contracts
{
    public interface IResourceRepository
    {

        Task<IEnumerable<Resource>> GetAllAsync();
        Task<Resource?> GetAsync(int id);

        Task<IEnumerable<object>> GetAllResourcesGroupedBySkillAsync();
    }
}
