using System.ComponentModel.DataAnnotations;
namespace quizApp.Models;

public class QuestionnarieViewModel 
{   
    [Required(ErrorMessage = "La pregunta es obligatorio")]
    public string Question { get; set; }
   [Required(ErrorMessage = "La respuesta correcta es obligatorio")]
    public string RigthAnswer { get; set; }  
   [Required(ErrorMessage = "Respuesta incorrecta #1 obligatorio")]
    public string WrongAnswer { get; set; }
   [Required(ErrorMessage = "Respuesta incorrecta #2 obligatorio")]
    public string WrongAnswerTwo { get; set; }
   [Required(ErrorMessage = "Respuesta incorrecta #3 obligatorio")]
    public string WrongAnswerThree { get; set; }
   

}


