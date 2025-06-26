using Backend_Biblioteca.Core.Application.Helpers;
using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Backend_Biblioteca.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Backend_Biblioteca.Core.Application;

public static class ServiceIntegration
{
    public static void AddCoreApplication(this IServiceCollection services)
    {
        #region services
        //aqui se inyectan los servicios, y no directamente en el program
        services.AddTransient<IPasswordHasher, PasswordHasher>();
        services.AddTransient<IUserService, UserService>();
        services.AddScoped<LoginService>();

        #endregion
    }
}