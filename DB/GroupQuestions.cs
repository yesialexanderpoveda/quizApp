using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB

{

public class GroupQuestions

{
  [Key] // Indica que esta es la clave primaria
    public int GroupQuestionId { get; set; }
    public string GroupQuestionType { get; set; }

    // Collection Navigation Property
    public ICollection<Questions> Questions { get; set; } = new List<Questions>();
}

}