using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartyPantz.Server.Migrations
{
    /// <inheritdoc />
    public partial class activity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Activity",
                table: "Skills",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ActivityDescription",
                table: "Skills",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Alphabet scavenger hunt", "Find items around the house that start with each letter of the alphabet and practice writing the letters." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Number matching game", "Match number cards to groups of objects and practice writing the numbers." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Counting jar", "Fill a jar with small items and count them together." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Activity", "ActivityDescription", "Description" },
                values: new object[] { "Shape hunt", "Find and identify shapes around the house or in nature.", "Learn to recognize basic shapes" });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Color sorting", "Sort colored objects into different color groups and practice naming the colors." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Craft time with scissors", "Cut out shapes from paper and create a simple craft." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Name practice sheets", "Trace and write their name using practice sheets." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Simple recipe or craft", "Follow a simple recipe or craft project with step-by-step instructions." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Playgroup games", "Participate in group games or activities with friends or family." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Activity", "ActivityDescription", "Description" },
                values: new object[] { "Turn-taking games", "Play games that require taking turns and listening to others.", "Develop basic social skills" });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Dressing practice", "Practice dressing themselves with simple clothing items." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Read together", "Read picture books and discuss the story to build vocabulary." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Math games", "Play simple addition and subtraction games using objects or drawings." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Rhyming games", "Play rhyming games or read rhyming books to practice recognizing rhymes." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Puzzle time", "Work on age-appropriate puzzles to develop problem-solving skills." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Obstacle course", "Create a simple obstacle course that includes running, jumping, and climbing." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Hygiene routine practice", "Practice handwashing, brushing teeth, and covering coughs/sneezes with fun songs." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Daily schedule", "Create a visual schedule with pictures to explain daily routines." });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Activity", "ActivityDescription" },
                values: new object[] { "Dress-up and role play", "Use costumes and props for imaginative play scenarios." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ActivityDescription",
                table: "Skills");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Learn to recognize basic shapes (circle, square, triangle, rectangle)");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "Develop basic social skills such as taking turns and listening to others");
        }
    }
}
