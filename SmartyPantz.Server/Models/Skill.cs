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
        
        public string? ActivityDescription { get; set; }
        
        public string? Activity { get; set; }
        
        public ICollection<Resource>? Resource { get; set; }

        public ICollection<UserSkill>? UserSkills { get; set; }

    }

    

}
