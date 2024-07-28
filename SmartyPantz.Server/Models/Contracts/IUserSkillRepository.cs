namespace SmartyPantz.Server.Models.Contracts
{
    public interface IUserSkillRepository
    {
        IEnumerable<UserSkill> GetSkillsForUser(int userId);
        void AddSkillsToUser(int userId, IEnumerable<int> skillIds);
        void RemoveSkillFromUser(int userId, int skillId);
    }
}
