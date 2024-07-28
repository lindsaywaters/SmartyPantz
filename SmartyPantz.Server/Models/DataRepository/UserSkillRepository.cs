using System.Collections.Generic;
using System.Linq;
using SmartyPantz.Server.Models.Contracts;
using Microsoft.EntityFrameworkCore;

namespace SmartyPantz.Server.Models
{
    public class UserSkillRepository : IUserSkillRepository
    {
        private readonly ApplicationContext _context;

        public UserSkillRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<UserSkill> GetSkillsForUser(int userId)
        {
            return _context.UserSkills
                .Include(us => us.Skill)
                .Where(us => us.UserId == userId)
                .ToList();
        }

        public void AddSkillsToUser(int userId, IEnumerable<int> skillIds)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            foreach (var skillId in skillIds)
            {
                if (!_context.UserSkills.Any(us => us.UserId == userId && us.SkillId == skillId))
                {
                    _context.UserSkills.Add(new UserSkill
                    {
                        UserId = userId,
                        SkillId = skillId,
                        IsNeeded = true 
                    });
                }
            }

            _context.SaveChanges();
        }

        public void RemoveSkillFromUser(int userId, int skillId)
        {
            var userSkill = _context.UserSkills
                .FirstOrDefault(us => us.UserId == userId && us.SkillId == skillId);
            if (userSkill != null)
            {
                _context.UserSkills.Remove(userSkill);
                _context.SaveChanges();
            }
        }
    }
}
