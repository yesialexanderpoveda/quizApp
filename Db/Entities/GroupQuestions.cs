using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB

{

public class GroupQuestions

{
  [Key] // Indica que esta es la clave primaria
    public int GroupQuestionId { get; set; }
    public string GroupQuestionName { get; set; }
    public int ResponseTimeInMinutes { get; set; }
    public string Description { get; set; }
    public byte[] Image { get; set; }
    public bool Access { get; set; }
    // Collection Navigation Property
    public ICollection<Questions> Questions { get; set; } = new List<Questions>();
}

}