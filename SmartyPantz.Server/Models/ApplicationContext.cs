using Microsoft.EntityFrameworkCore;
using MySql.Data;

namespace SmartyPantz.Server.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Resource> Resources { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Skill>()
                .HasMany(s => s.Resource)
                .WithOne(r => r.Skill)
                .HasForeignKey(r => r.SkillId);
            
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

            modelBuilder.Entity<Resource>().HasData(
                new Resource { Id = 1, SkillId = 1, Type = "Book", Name = "Chicka Chicka Boom Boom by Bill Martin Jr. and John Archambault" },
                new Resource { Id = 2, SkillId = 1, Type = "Website", Name = "https://starfall.com" },
                new Resource { Id = 3, SkillId = 1, Type = "App", Name = "Endless Alphabet" },
                new Resource { Id = 4, SkillId = 1, Type = "App", Name = "ABCmouse" },

                new Resource { Id = 5, SkillId = 2, Type = "Book", Name = "Counting Kisses by Karen Katz" },
                new Resource { Id = 6, SkillId = 2, Type = "Website", Name = "https://mathplayground.com" },
                new Resource { Id = 7, SkillId = 2, Type = "Website", Name = "https://ixl.com" },
                new Resource { Id = 8, SkillId = 2, Type = "App", Name = "Todo Math" },
                new Resource { Id = 9, SkillId = 2, Type = "App", Name = "Count and Write Numbers" },

                new Resource { Id = 10, SkillId = 3, Type = "Book", Name = "The Very Hungry Caterpillar by Eric Carle" },
                new Resource { Id = 11, SkillId = 3, Type = "Website", Name = "https://pbskids.org" },
                new Resource { Id = 12, SkillId = 3, Type = "Website", Name = "https://coolmath4kids.com" },
                new Resource { Id = 13, SkillId = 3, Type = "App", Name = "Count and Match" },
                new Resource { Id = 14, SkillId = 3, Type = "App", Name = "Number Bingo" },

                new Resource { Id = 15, SkillId = 4, Type = "Book", Name = "Shapes by David A. Carter" },
                new Resource { Id = 16, SkillId = 4, Type = "Website", Name = "https://abcmouse.com" },
                new Resource { Id = 17, SkillId = 4, Type = "Website", Name = "https://kidsongs.com" },
                new Resource { Id = 18, SkillId = 4, Type = "App", Name = "Shapes & Colors by Intellijoy" },
                new Resource { Id = 19, SkillId = 4, Type = "App", Name = "Kids Shapes" },

                new Resource { Id = 20, SkillId = 5, Type = "Book", Name = "Brown Bear, Brown Bear, What Do You See? by Bill Martin Jr. and Eric Carle" },
                new Resource { Id = 21, SkillId = 5, Type = "Website", Name = "https://color-game.com" },
                new Resource { Id = 22, SkillId = 5, Type = "Website", Name = "https://sesamestreet.org" },
                new Resource { Id = 23, SkillId = 5, Type = "App", Name = "Color Monster" },
                new Resource { Id = 24, SkillId = 5, Type = "App", Name = "My First Colors" },

                new Resource { Id = 25, SkillId = 6, Type = "Book", Name = "The Busy Book by Trish Kuffner" },
                new Resource { Id = 26, SkillId = 6, Type = "Website", Name = "https://funlearningforkids.com" },
                new Resource { Id = 27, SkillId = 6, Type = "Website", Name = "https://playdoughtoplato.com" },
                new Resource { Id = 28, SkillId = 6, Type = "App", Name = "Fine Motor Fun" },
                new Resource { Id = 29, SkillId = 6, Type = "App", Name = "Toca Boca Kitchen" },

                new Resource { Id = 30, SkillId = 7, Type = "Book", Name = "The Name Jar by Yangsook Choi" },
                new Resource { Id = 31, SkillId = 7, Type = "Website", Name = "https://name-tracing.com" },
                new Resource { Id = 32, SkillId = 7, Type = "Website", Name = "https://starfall.com" },
                new Resource { Id = 33, SkillId = 7, Type = "App", Name = "Writing Wizard" },
                new Resource { Id = 34, SkillId = 7, Type = "App", Name = "Tracing Letters & Numbers" },

                new Resource { Id = 35, SkillId = 8, Type = "Book", Name = "If You Give a Mouse a Cookie by Laura Numeroff" },
                new Resource { Id = 36, SkillId = 8, Type = "Website", Name = "https://kidsongs.com" },
                new Resource { Id = 37, SkillId = 8, Type = "Website", Name = "https://abcmouse.com" },

                new Resource { Id = 38, SkillId = 9, Type = "Book", Name = "The Family Book by Todd Parr" },
                new Resource { Id = 39, SkillId = 9, Type = "Website", Name = "https://pbs.org/parents" },
                new Resource { Id = 40, SkillId = 9, Type = "Website", Name = "https://k5learning.com" },

                new Resource { Id = 41, SkillId = 10, Type = "Book", Name = "Llama Llama Time to Share by Anna Dewdney" },
                new Resource { Id = 42, SkillId = 10, Type = "Website", Name = "https://childdevelopmentinfo.com" },
                new Resource { Id = 43, SkillId = 10, Type = "Website", Name = "https://parenting.com" },

                new Resource { Id = 44, SkillId = 11, Type = "Book", Name = "The Berenstain Bears Visit the Dentist by Stan & Jan Berenstain" },
                new Resource { Id = 45, SkillId = 11, Type = "Website", Name = "https://supernanny.co.uk" },
                new Resource { Id = 46, SkillId = 11, Type = "Website", Name = "https://positiveparenting.com" },

                new Resource { Id = 47, SkillId = 12, Type = "Book", Name = "The Snowy Day by Ezra Jack Keats" },
                new Resource { Id = 48, SkillId = 12, Type = "Website", Name = "https://readbrightly.com" },
                new Resource { Id = 49, SkillId = 12, Type = "Website", Name = "https://literacytrust.org.uk" },

                new Resource { Id = 50, SkillId = 13, Type = "Book", Name = "1, 2, 3 to the Zoo by Eric Carle" },
                new Resource { Id = 51, SkillId = 13, Type = "Website", Name = "https://abcya.com" },
                new Resource { Id = 52, SkillId = 13, Type = "Website", Name = "https://education.com" },

                new Resource { Id = 53, SkillId = 14, Type = "Book", Name = "Dr. Seuss's ABC by Dr. Seuss" },
                new Resource { Id = 54, SkillId = 14, Type = "Website", Name = "https://readingrockets.org" },
                new Resource { Id = 55, SkillId = 14, Type = "Website", Name = "https://scholastic.com" },

                new Resource { Id = 56, SkillId = 15, Type = "Book", Name = "Rosie’s Walk by Pat Hutchins" },
                new Resource { Id = 57, SkillId = 15, Type = "Website", Name = "https://funbrain.com" },
                new Resource { Id = 58, SkillId = 15, Type = "Website", Name = "https://tinkercad.com" },

                new Resource { Id = 59, SkillId = 16, Type = "Book", Name = "From Head to Toe by Eric Carle" },
                new Resource { Id = 60, SkillId = 16, Type = "Website", Name = "https://kidshealth.org" },
                new Resource { Id = 61, SkillId = 16, Type = "Website", Name = "https://verywellfamily.com" },

                new Resource { Id = 62, SkillId = 17, Type = "Book", Name = "The Berenstain Bears and the Trouble with Chores by Stan & Jan Berenstain" },
                new Resource { Id = 63, SkillId = 17, Type = "Website", Name = "https://kidshealth.org" },
                new Resource { Id = 64, SkillId = 17, Type = "Website", Name = "https://childrenshospital.org" },

                new Resource { Id = 65, SkillId = 18, Type = "Book", Name = "What Time Is It, Mr. Crocodile? by Judy Sierra" },
                new Resource { Id = 66, SkillId = 18, Type = "Website", Name = "https://time-for-kids.com" },
                new Resource { Id = 67, SkillId = 18, Type = "Website", Name = "https://teachervision.com" },

                new Resource { Id = 68, SkillId = 19, Type = "Book", Name = "Not a Box by Antoinette Portis" },
                new Resource { Id = 69, SkillId = 19, Type = "Website", Name = "https://imaginativeplay.com" },
                new Resource { Id = 70, SkillId = 19, Type = "Website", Name = "https://kidspot.com.au" }
                );
        }
    }
}
