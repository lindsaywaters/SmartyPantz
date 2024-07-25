using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartyPantz.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsChecked = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChildsName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChildsAge = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Description", "IsChecked", "Title" },
                values: new object[,]
                {
                    { 1, "Learn to recognize and write letters of the alphabet", false, "isLetters" },
                    { 2, "Learn to recognize and write numbers 1-20", false, "isNumbers" },
                    { 3, "Learn to count objects up to 20", false, "isCounting" },
                    { 4, "Learn to recognize basic shapes (circle, square, triangle, rectangle)", false, "isShapes" },
                    { 5, "Learn to identify colors", false, "isColors" },
                    { 6, "Develop fine motor skills through activities such as cutting with scissors, coloring, and tracing", false, "isFineMotor" },
                    { 7, "Learn to recognize and write their own name", false, "isNameWriting" },
                    { 8, "Learn to follow simple instructions", false, "isInstructions" },
                    { 9, "Learn to participate in group activities and share with others", false, "isGroupActivities" },
                    { 10, "Develop basic social skills such as taking turns and listening to others", false, "isSocialSkills" },
                    { 11, "Develop independence in tasks like dressing themselves and cleaning up after activities", false, "isIndependence" },
                    { 12, "Build vocabulary and language skills through reading and conversation", false, "isVocabulary" },
                    { 13, "Develop basic math skills such as understanding basic addition and subtraction concepts", false, "isMath" },
                    { 14, "Develop pre-reading skills such as recognizing rhyming words and understanding basic sight words", false, "isPreReading" },
                    { 15, "Develop basic problem-solving skills through puzzles and simple games", false, "isProblemSolving" },
                    { 16, "Develop gross motor skills through activities such as running, jumping, and climbing", false, "isGrossMotor" },
                    { 17, "Practice good hygiene habits such as washing hands and covering coughs/sneezes", false, "isHygiene" },
                    { 18, "Understand basic concepts of time such as morning, afternoon, and evening", false, "isTime" },
                    { 19, "Engage in imaginative play and creativity", false, "isCreativity" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "SkillId", "Type" },
                values: new object[,]
                {
                    { 1, "Chicka Chicka Boom Boom by Bill Martin Jr. and John Archambault", 1, "Book" },
                    { 2, "https://starfall.com", 1, "Website" },
                    { 3, "Endless Alphabet", 1, "App" },
                    { 4, "ABCmouse", 1, "App" },
                    { 5, "Counting Kisses by Karen Katz", 2, "Book" },
                    { 6, "https://mathplayground.com", 2, "Website" },
                    { 7, "https://ixl.com", 2, "Website" },
                    { 8, "Todo Math", 2, "App" },
                    { 9, "Count and Write Numbers", 2, "App" },
                    { 10, "The Very Hungry Caterpillar by Eric Carle", 3, "Book" },
                    { 11, "https://pbskids.org", 3, "Website" },
                    { 12, "https://coolmath4kids.com", 3, "Website" },
                    { 13, "Count and Match", 3, "App" },
                    { 14, "Number Bingo", 3, "App" },
                    { 15, "Shapes by David A. Carter", 4, "Book" },
                    { 16, "https://abcmouse.com", 4, "Website" },
                    { 17, "https://kidsongs.com", 4, "Website" },
                    { 18, "Shapes & Colors by Intellijoy", 4, "App" },
                    { 19, "Kids Shapes", 4, "App" },
                    { 20, "Brown Bear, Brown Bear, What Do You See? by Bill Martin Jr. and Eric Carle", 5, "Book" },
                    { 21, "https://color-game.com", 5, "Website" },
                    { 22, "https://sesamestreet.org", 5, "Website" },
                    { 23, "Color Monster", 5, "App" },
                    { 24, "My First Colors", 5, "App" },
                    { 25, "The Busy Book by Trish Kuffner", 6, "Book" },
                    { 26, "https://funlearningforkids.com", 6, "Website" },
                    { 27, "https://playdoughtoplato.com", 6, "Website" },
                    { 28, "Fine Motor Fun", 6, "App" },
                    { 29, "Toca Boca Kitchen", 6, "App" },
                    { 30, "The Name Jar by Yangsook Choi", 7, "Book" },
                    { 31, "https://name-tracing.com", 7, "Website" },
                    { 32, "https://starfall.com", 7, "Website" },
                    { 33, "Writing Wizard", 7, "App" },
                    { 34, "Tracing Letters & Numbers", 7, "App" },
                    { 35, "If You Give a Mouse a Cookie by Laura Numeroff", 8, "Book" },
                    { 36, "https://kidsongs.com", 8, "Website" },
                    { 37, "https://abcmouse.com", 8, "Website" },
                    { 38, "The Family Book by Todd Parr", 9, "Book" },
                    { 39, "https://pbs.org/parents", 9, "Website" },
                    { 40, "https://k5learning.com", 9, "Website" },
                    { 41, "Llama Llama Time to Share by Anna Dewdney", 10, "Book" },
                    { 42, "https://childdevelopmentinfo.com", 10, "Website" },
                    { 43, "https://parenting.com", 10, "Website" },
                    { 44, "The Berenstain Bears Visit the Dentist by Stan & Jan Berenstain", 11, "Book" },
                    { 45, "https://supernanny.co.uk", 11, "Website" },
                    { 46, "https://positiveparenting.com", 11, "Website" },
                    { 47, "The Snowy Day by Ezra Jack Keats", 12, "Book" },
                    { 48, "https://readbrightly.com", 12, "Website" },
                    { 49, "https://literacytrust.org.uk", 12, "Website" },
                    { 50, "1, 2, 3 to the Zoo by Eric Carle", 13, "Book" },
                    { 51, "https://abcya.com", 13, "Website" },
                    { 52, "https://education.com", 13, "Website" },
                    { 53, "Dr. Seuss's ABC by Dr. Seuss", 14, "Book" },
                    { 54, "https://readingrockets.org", 14, "Website" },
                    { 55, "https://scholastic.com", 14, "Website" },
                    { 56, "Rosie’s Walk by Pat Hutchins", 15, "Book" },
                    { 57, "https://funbrain.com", 15, "Website" },
                    { 58, "https://tinkercad.com", 15, "Website" },
                    { 59, "From Head to Toe by Eric Carle", 16, "Book" },
                    { 60, "https://kidshealth.org", 16, "Website" },
                    { 61, "https://verywellfamily.com", 16, "Website" },
                    { 62, "The Berenstain Bears and the Trouble with Chores by Stan & Jan Berenstain", 17, "Book" },
                    { 63, "https://kidshealth.org", 17, "Website" },
                    { 64, "https://childrenshospital.org", 17, "Website" },
                    { 65, "What Time Is It, Mr. Crocodile? by Judy Sierra", 18, "Book" },
                    { 66, "https://time-for-kids.com", 18, "Website" },
                    { 67, "https://teachervision.com", 18, "Website" },
                    { 68, "Not a Box by Antoinette Portis", 19, "Book" },
                    { 69, "https://imaginativeplay.com", 19, "Website" },
                    { 70, "https://kidspot.com.au", 19, "Website" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_SkillId",
                table: "Resources",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
