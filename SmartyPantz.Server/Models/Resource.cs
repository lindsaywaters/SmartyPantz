namespace SmartyPantz.Server.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
