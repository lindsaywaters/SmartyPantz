using System.Collections.Generic;
using System.Linq;
using SmartyPantz.Server.Models.Contracts;
using Microsoft.EntityFrameworkCore;

namespace SmartyPantz.Server.Models
{
    public class UserSkillRepository : IUserSkillRepository
    {
        private readonly ApplicationContext _context;

        IQueryable<UserSkill> IUserSkillRepository.UserSkill => throw new NotImplementedException();

        public UserSkillRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<UserSkill?> GetUserSkillAsync(int userId, int skillId)
        {
            return await _context.UserSkills
                .FirstOrDefaultAsync(us => us.UserId == userId && us.SkillId == skillId);
        }

        public async Task UpdateUserSkillAsync(UserSkill userSkill)
        {
            _context.UserSkills.Update(userSkill);
            await _context.SaveChangesAsync();
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
            var existingSkills = _context.UserSkills
                                     .Where(us => us.UserId == userId)
                                     .Select(us => us.SkillId)
                                     .ToHashSet();

            var newSkills = skillIds.Where(skillId => !existingSkills.Contains(skillId))
                                    .Select(skillId => new UserSkill
                                    {
                                        UserId = userId,
                                        SkillId = skillId
                                    });

            _context.UserSkills.AddRange(newSkills);
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
        public void RemoveSkillsFromUser(int userId, IEnumerable<int> skillIds)
        {
            // Fetch the user skills that match the userId and skillIds
            var userSkills = _context.UserSkills
                .Where(us => us.UserId == userId && skillIds.Contains(us.SkillId))
                .ToList(); // Execute the query and get the results

            // Remove the fetched user skills from the context
            if (userSkills.Any())
            {
                _context.UserSkills.RemoveRange(userSkills);
                _context.SaveChanges();
            }
        }





    }
}
