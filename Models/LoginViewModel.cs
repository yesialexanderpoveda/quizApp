using System.ComponentModel.DataAnnotations;

namespace quizApp.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "El correo electrónico es obligatorio")]
    [EmailAddress(ErrorMessage = "Correo electrónico no validao")]
    public string Email { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}