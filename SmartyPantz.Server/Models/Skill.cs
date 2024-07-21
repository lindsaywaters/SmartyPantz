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
    }
}
