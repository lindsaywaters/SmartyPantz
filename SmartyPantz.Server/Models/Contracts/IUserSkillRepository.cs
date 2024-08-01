namespace SmartyPantz.Server.Models.Contracts
{
    public interface IUserSkillRepository
    {
        IQueryable<UserSkill> UserSkill { get; }
        IEnumerable<UserSkill> GetSkillsForUser(int userId);
        void AddSkillsToUser(int userId, IEnumerable<int> skillIds);
        void RemoveSkillFromUser(int userId, int skillId);
        

        void RemoveSkillsFromUser(int userId, IEnumerable<int> skillIds);
        Task<UserSkill?> GetUserSkillAsync(int userId, int skillId);
        Task UpdateUserSkillAsync(UserSkill userSkill);

    }
}
