using Backend_Biblioteca.Core.Domain.Entities;

namespace Backend_Biblioteca.Core.Application.Interfaces.Services;

public interface IAuthService
{
    Task<string> GenerateTokenAsync(User user);
    Task<bool>ValidateUserCredentialsAsync(string email, string password);
}