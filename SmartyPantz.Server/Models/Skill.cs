using System.ComponentModel.DataAnnotations.Schema;

namespace SmartyPantz.Server.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string? Description { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Title { get; set; }
        public bool IsChecked { get; set; }

        
        public ICollection<Resource>? Resource { get; set; }

        public ICollection<UserSkill>? UserSkills { get; set; }

    }

    public class Resource
    {
        public int Id { get; set; }
        public int SkillId { get; set; }  
        public Skill Skill { get; set; }  
        public string Type { get; set; }
        public string Name { get; set; }
    }

}
