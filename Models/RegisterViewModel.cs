using System.ComponentModel.DataAnnotations;

namespace quizApp.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Name { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio")]
    [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
    public string Email{ get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
