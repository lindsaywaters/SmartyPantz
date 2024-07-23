using System.ComponentModel.DataAnnotations;

namespace SmartyPantz.Server.Models
{
    public class User
    {
        public int Id { get; set; } 

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string ChildsName { get; set; }
        public int ChildsAge { get; set; }

        [Required]
        public string PasswordHash { get; set; } 
    }
}
