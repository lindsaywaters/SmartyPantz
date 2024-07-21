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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
