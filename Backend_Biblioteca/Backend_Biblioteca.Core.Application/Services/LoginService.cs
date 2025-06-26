using Backend_Biblioteca.Core.Application.DTO;
using Backend_Biblioteca.Core.Application.Helpers;
using Backend_Biblioteca.Core.Application.Interfaces.Repositories;
using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Backend_Biblioteca.Core.Application.ViewModels.User;
using Microsoft.Extensions.Configuration;

namespace Backend_Biblioteca.Core.Application.Services;

public class LoginService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IConfiguration _configuration;
    private readonly IAuthService _authService;

    public LoginService(IUserRepository userRepository, IPasswordHasher passwordHasher, IConfiguration configuration, IAuthService authService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _configuration = configuration;
        _authService = authService;
    }

    public async Task<LoginResult> LoginAsync(LoginViewModel entity)
    {
        var user = await _userRepository.GetByEmail(entity.Email);
        
        if(user == null)
            return new LoginResult() { IsSuccess = false, Message = "User not found" };
        
        if(!_passwordHasher.VerifyHashedPassword(entity.Password, user.PasswordHash))
            return new LoginResult() { IsSuccess = false, Message = "Invalid password" };

        var token = await _authService.GenerateTokenAsync(user);
        return new LoginResult
        {
            IsSuccess = true,
            Token = token,
            UserVm = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
            }
        };
    }
}