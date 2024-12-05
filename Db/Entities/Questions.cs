
namespace DB
{
 public class Questions
 {
    public int QuestionsId { get; set; }
    public string Question { get; set; }
    public string RigthAnswer { get; set; }  
    public string WrongAnswer { get; set; }
    public string WrongAnswerTwo { get; set; }
    public string WrongAnswerThree { get; set; }
    public int GroupQuestionId { get; set; }
    public GroupQuestions GroupQuestions { get; set; }  
 }
}