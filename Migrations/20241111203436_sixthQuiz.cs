using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quizApp.Migrations
{
    /// <inheritdoc />
    public partial class sixthQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Technology",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "GroupQuestionId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GroupQuestions",
                columns: table => new
                {
                    GroupQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupQuestionType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupQuestions", x => x.GroupQuestionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_GroupQuestionId",
                table: "Questions",
                column: "GroupQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_GroupQuestions_GroupQuestionId",
                table: "Questions",
                column: "GroupQuestionId",
                principalTable: "GroupQuestions",
                principalColumn: "GroupQuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_GroupQuestions_GroupQuestionId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "GroupQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_GroupQuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "GroupQuestionId",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "Technology",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
