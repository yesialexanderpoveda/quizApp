using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quizApp.Migrations
{
    /// <inheritdoc />
    public partial class ninthQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AplicationUserId",
                table: "GroupQuestions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupQuestions_AplicationUserId",
                table: "GroupQuestions",
                column: "AplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupQuestions_AspNetUsers_AplicationUserId",
                table: "GroupQuestions",
                column: "AplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupQuestions_AspNetUsers_AplicationUserId",
                table: "GroupQuestions");

            migrationBuilder.DropIndex(
                name: "IX_GroupQuestions_AplicationUserId",
                table: "GroupQuestions");

            migrationBuilder.DropColumn(
                name: "AplicationUserId",
                table: "GroupQuestions");
        }
    }
}
