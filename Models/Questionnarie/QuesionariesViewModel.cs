using System.ComponentModel.DataAnnotations;

namespace quizApp.Models;

public class QuestionnarieSViewModel
{

    [Required(ErrorMessage = "Nombre de cuestionario obligatorio")]
    public string GroupQuestionName { get; set; }
    [Required(ErrorMessage = "Tiempo en minutos obligatorio")]
    public int ResponseTimeInMinutes { get; set; } 

    [Required(ErrorMessage = "La descripción es obligatoria")]
    public string Description { get; set; }

    public byte[] Image { get; set; }

    public bool Access { get; set; }

    public ICollection<QuestionnarieViewModel> Questionnarie { get; set; } = new List<QuestionnarieViewModel>();
} 


