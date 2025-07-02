using System.ComponentModel.DataAnnotations;

namespace Backend_Biblioteca.Core.Application.ViewModels.User;

public class SaveUserViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    [RegularExpression(@"^[^@]+@itla\.edu\.do$", ErrorMessage = "Solo se permite correos institucional del ITLA")]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
    
    [Required]
    public string Role { get; set; }
}