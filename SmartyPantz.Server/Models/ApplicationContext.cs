using Microsoft.EntityFrameworkCore;

namespace SmartyPantz.Server.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(


                new Skill { Id = 1, Description = "Learn to recognize and write letters of the alphabet", Title = "isLetters", IsChecked = false },
                new Skill { Id = 2, Description = "Learn to recognize and write numbers 1-20", Title = "isNumbers", IsChecked = false },
                new Skill { Id = 3, Description = "Learn to count objects up to 20", Title = "isCounting", IsChecked = false },
                new Skill { Id = 4, Description = "Learn to recognize basic shapes (circle, square, triangle, rectangle)", Title = "isShapes", IsChecked = false },
                new Skill { Id = 5, Description = "Learn to identify colors", Title = "isColors", IsChecked = false },
                new Skill { Id = 6, Description = "Develop fine motor skills through activities such as cutting with scissors, coloring, and tracing", Title = "isFineMotor", IsChecked = false },
                new Skill { Id = 7, Description = "Learn to recognize and write their own name", Title = "isNameWriting", IsChecked = false },
                new Skill { Id = 8, Description = "Learn to follow simple instructions", Title = "isInstructions", IsChecked = false },
                new Skill { Id = 9, Description = "Learn to participate in group activities and share with others", Title = "isGroupActivities", IsChecked = false },
                new Skill { Id = 10, Description = "Develop basic social skills such as taking turns and listening to others", Title = "isSocialSkills", IsChecked = false },
                new Skill { Id = 11, Description = "Develop independence in tasks like dressing themselves and cleaning up after activities", Title = "isIndependence", IsChecked = false },
                new Skill { Id = 12, Description = "Build vocabulary and language skills through reading and conversation", Title = "isVocabulary", IsChecked = false },
                new Skill { Id = 13, Description = "Develop basic math skills such as understanding basic addition and subtraction concepts", Title = "isMath", IsChecked = false },
                new Skill { Id = 14, Description = "Develop pre-reading skills such as recognizing rhyming words and understanding basic sight words", Title = "isPreReading", IsChecked = false },
                new Skill { Id = 15, Description = "Develop basic problem-solving skills through puzzles and simple games", Title = "isProblemSolving", IsChecked = false },
                new Skill { Id = 16, Description = "Develop gross motor skills through activities such as running, jumping, and climbing", Title = "isGrossMotor", IsChecked = false },
                new Skill { Id = 17, Description = "Practice good hygiene habits such as washing hands and covering coughs/sneezes", Title = "isHygiene", IsChecked = false },
                new Skill { Id = 18, Description = "Understand basic concepts of time such as morning, afternoon, and evening", Title = "isTime", IsChecked = false },
                new Skill { Id = 19, Description = "Engage in imaginative play and creativity", Title = "isCreativity", IsChecked = false }
            );
        }
    }
}
