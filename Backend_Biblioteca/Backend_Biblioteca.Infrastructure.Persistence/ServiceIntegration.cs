using Backend_Biblioteca.Core.Application.Interfaces.Repositories;
using Backend_Biblioteca.Infrastructure.Persistence.Contexts;
using Backend_Biblioteca.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend_Biblioteca.Infrastructure.Persistence;

public static class ServiceIntegration
{
    public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        #region contexts
        //esta es la inyeccion del contexto de la db
        //db sql server
//        services.AddDbContext<ApplicationDbContext>(options =>
//            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
//                m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        
        //db mysql --esto solo es para DARLYN testear como uso linux
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 36)) // Usa aquí la versión de tu servidor MySQL
            )
        );
        #endregion
        
                
        //aqui se inyectan los servicios
        #region services

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IUserRepository, UserRepository>();

        #endregion
    }
}