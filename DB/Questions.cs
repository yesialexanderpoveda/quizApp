
namespace DB
{
 public class Questions
 {
    public int QuestionsId { get; set; }
    public string RigthAnswer { get; set; }  
    public string WrongAnswer { get; set; }
    public string WrongAnswerTwo { get; set; }
    public string WrongAnswerThree { get; set; }
    public bool Access { get; set; }
    public byte[] Image { get; set; }

    // Foreign Key
    public int GroupQuestionId { get; set; }

    // Navigation Property
    public GroupQuestions GroupQuestions { get; set; }  
 }
}