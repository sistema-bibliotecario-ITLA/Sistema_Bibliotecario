using Backend_Biblioteca.Core.Application.ViewModels.User;

namespace Backend_Biblioteca.Core.Application.DTO;

public class LoginResult
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsSuccess { get; set; }
    public UserViewModel UserVm { get; set; }
}