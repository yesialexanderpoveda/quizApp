using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quizApp.Migrations
{
    /// <inheritdoc />
    public partial class fifthQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Access",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Access",
                table: "Questions");
        }
    }
}
