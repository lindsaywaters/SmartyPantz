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
        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<UserSkill> UserSkills { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserProfile>()
                .HasOne(up => up.User)
                .WithOne(u => u.UserProfile)
                .HasForeignKey<UserProfile>(u => u.UserId);

            modelBuilder.Entity<Skill>()
                .HasMany(s => s.Resource)
                .WithOne(r => r.Skill)
                .HasForeignKey(r => r.SkillId);
            
            modelBuilder.Entity<UserSkill>()
              .HasKey(us => new { us.UserId, us.SkillId });

            modelBuilder.Entity<UserSkill>()
                 .HasOne(us => us.User)
                 .WithMany(u => u.UserSkills)
                 .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<UserSkill>()
                 .HasOne(us => us.Skill)
                 .WithMany(s => s.UserSkills)
                 .HasForeignKey(us => us.SkillId);


            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Title = "Alphabet Recognition and Writing", Description = "Learn to recognize and write letters of the alphabet", Activity = "Alphabet scavenger hunt", ActivityDescription = "Find items around the house that start with each letter of the alphabet and practice writing the letters." },
                new Skill { Id = 2, Title = "Number Recognition and Writing", Description = "Learn to recognize and write numbers 1-20", Activity = "Number matching game", ActivityDescription = "Match number cards to groups of objects and practice writing the numbers." },
                new Skill { Id = 3, Title = "Counting Objects", Description = "Learn to count objects up to 20", Activity = "Counting jar", ActivityDescription = "Fill a jar with small items and count them together." },
                new Skill { Id = 4, Title = "Shape Recognition", Description = "Learn to recognize basic shapes", Activity = "Shape hunt", ActivityDescription = "Find and identify shapes around the house or in nature." },
                new Skill { Id = 5, Title = "Color Identification", Description = "Learn to identify colors", Activity = "Color sorting", ActivityDescription = "Sort colored objects into different color groups and practice naming the colors." },
                new Skill { Id = 6, Title = "Fine Motor Skills Development", Description = "Develop fine motor skills through activities such as cutting with scissors, coloring, and tracing", Activity = "Craft time with scissors", ActivityDescription = "Cut out shapes from paper and create a simple craft." },
                new Skill { Id = 7, Title = "Name Writing", Description = "Learn to recognize and write their own name", Activity = "Name practice sheets", ActivityDescription = "Trace and write their name using practice sheets." },
                new Skill { Id = 8, Title = "Following Instructions", Description = "Learn to follow simple instructions", Activity = "Simple recipe or craft", ActivityDescription = "Follow a simple recipe or craft project with step-by-step instructions." },
                new Skill { Id = 9, Title = "Group Participation", Description = "Learn to participate in group activities and share with others", Activity = "Playgroup games", ActivityDescription = "Participate in group games or activities with friends or family." },
                new Skill { Id = 10, Title = "Social Skills", Description = "Develop basic social skills", Activity = "Turn-taking games", ActivityDescription = "Play games that require taking turns and listening to others." },
                new Skill { Id = 11, Title = "Independence in Tasks", Description = "Develop independence in tasks like dressing themselves and cleaning up after activities", Activity = "Dressing practice", ActivityDescription = "Practice dressing themselves with simple clothing items." },
                new Skill { Id = 12, Title = "Vocabulary and Language Skills", Description = "Build vocabulary and language skills through reading and conversation", Activity = "Read together", ActivityDescription = "Read picture books and discuss the story to build vocabulary." },
                new Skill { Id = 13, Title = "Basic Math Skills", Description = "Develop basic math skills such as understanding basic addition and subtraction concepts", Activity = "Math games", ActivityDescription = "Play simple addition and subtraction games using objects or drawings." },
                new Skill { Id = 14, Title = "Pre-Reading Skills", Description = "Develop pre-reading skills such as recognizing rhyming words and understanding basic sight words", Activity = "Rhyming games", ActivityDescription = "Play rhyming games or read rhyming books to practice recognizing rhymes." },
                new Skill { Id = 15, Title = "Problem-Solving Skills", Description = "Develop basic problem-solving skills through puzzles and simple games", Activity = "Puzzle time", ActivityDescription = "Work on age-appropriate puzzles to develop problem-solving skills." },
                new Skill { Id = 16, Title = "Gross Motor Skills", Description = "Develop gross motor skills through activities such as running, jumping, and climbing", Activity = "Obstacle course", ActivityDescription = "Create a simple obstacle course that includes running, jumping, and climbing." },
                new Skill { Id = 17, Title = "Hygiene Habits", Description = "Practice good hygiene habits such as washing hands and covering coughs/sneezes", Activity = "Hygiene routine practice", ActivityDescription = "Practice handwashing, brushing teeth, and covering coughs/sneezes with fun songs." },
                new Skill { Id = 18, Title = "Understanding Time Concepts", Description = "Understand basic concepts of time such as morning, afternoon, and evening", Activity = "Daily schedule", ActivityDescription = "Create a visual schedule with pictures to explain daily routines." },
                new Skill { Id = 19, Title = "Imaginative Play and Creativity", Description = "Engage in imaginative play and creativity", Activity = "Dress-up and role play", ActivityDescription = "Use costumes and props for imaginative play scenarios." }
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
