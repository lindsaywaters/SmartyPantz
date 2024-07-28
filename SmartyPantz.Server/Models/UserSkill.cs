using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartyPantz.Server.Models
{
    public class UserSkill
    {
        public int UserId { get; set; }
        public User? User { get; set; } 

        public int SkillId { get; set; }
        public Skill? Skill { get; set; }

        public bool IsNeeded { get; set; }
    }
}
