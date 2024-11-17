using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quizApp.Migrations
{
    /// <inheritdoc />
    public partial class seventhQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Access",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "GroupQuestionType",
                table: "GroupQuestions",
                newName: "GroupQuestionName");

            migrationBuilder.AddColumn<int>(
                name: "Answered",
                table: "Result",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Access",
                table: "GroupQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GroupQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "GroupQuestions",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<int>(
                name: "ResponseTimeInMinutes",
                table: "GroupQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answered",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Access",
                table: "GroupQuestions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "GroupQuestions");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "GroupQuestions");

            migrationBuilder.DropColumn(
                name: "ResponseTimeInMinutes",
                table: "GroupQuestions");

            migrationBuilder.RenameColumn(
                name: "GroupQuestionName",
                table: "GroupQuestions",
                newName: "GroupQuestionType");

            migrationBuilder.AddColumn<bool>(
                name: "Access",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Questions",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
