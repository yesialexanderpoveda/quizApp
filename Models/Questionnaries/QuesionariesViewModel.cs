namespace quizApp.Models;

public class QuestionnarieSViewModel
{

    public int GroupQuestionId { get; set; }
    public string GroupQuestionType { get; set; }
    public int ResponseTimeInMinutes { get; set; }
    public ICollection<QuestionnarieViewModel> Questionnarie { get; set; } = new List<QuestionnarieViewModel>();
} 


