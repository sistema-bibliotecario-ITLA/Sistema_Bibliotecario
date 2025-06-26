using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend_Biblioteca.Core.Application.Helpers;
using Backend_Biblioteca.Core.Application.Interfaces.Repositories;
using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Backend_Biblioteca.Core.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Backend_Biblioteca.Middlewares;

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(IConfiguration config, IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _config = config;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    

    public async Task<string> GenerateTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<bool> ValidateUserCredentialsAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmail(email);
        if (user == null) return false;

        return _passwordHasher.VerifyHashedPassword(password, user.PasswordHash);
    }
}