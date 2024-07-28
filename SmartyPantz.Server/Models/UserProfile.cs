using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartyPantz.Server.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

       

        public ICollection<UserSkill> UserSkills { get; set; } 

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
