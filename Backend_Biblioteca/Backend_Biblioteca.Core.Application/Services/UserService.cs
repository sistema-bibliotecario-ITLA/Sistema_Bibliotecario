using Backend_Biblioteca.Core.Application.Helpers;
using Backend_Biblioteca.Core.Application.Interfaces.Repositories;
using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Backend_Biblioteca.Core.Application.ViewModels.User;
using Backend_Biblioteca.Core.Domain.Entities;

namespace Backend_Biblioteca.Core.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(IUserRepository repository, IPasswordHasher passwordHasher)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
    }

    public async Task<IEnumerable<UserViewModel>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();
        //NOTA EC:
        //esto busca el servicio en el repositorio, y selecciona solo lo que va a usar con el viewmodel, manda al viewmodel lo que esta
        //en dicha tabla
        var usersVm = users.Select(user => new UserViewModel
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            Role = user.Role,
        });
        
        return usersVm;
    }

    public async Task<UserViewModel> GetByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);

        //esto lo mismo que arriba
        //solo sobreescribe lo que queremos exponer de la entidad mandandole al cliente solo que tiene que ver 
        UserViewModel userVm = new();
        userVm.Id = user.Id;
        userVm.Email = user.Email;
        userVm.Name = user.Name;
        userVm.Role = user.Role;
        
        return userVm;
    }

    public async Task<UserViewModel> GetByEmailAsync(string email)
    {
        var user = await _repository.GetByEmail(email);

        //esto lo mismo que arriba
        //solo sobreescribe lo que queremos exponer de la entidad mandandole al cliente solo que tiene que ver 
        UserViewModel userVm = new();
        userVm.Id = user.Id;
        userVm.Email = user.Email;
        userVm.Name = user.Name;
        userVm.Role = user.Role;
        
        return userVm;
    }

    public async Task AddAsync(SaveUserViewModel userVm)
    {
        User user = new()
        {
            Email = userVm.Email,
            Name = userVm.Name,
            PasswordHash = _passwordHasher.HashPassword(userVm.Password),
            Role = userVm.Role ?? "User" // Opcional: asigna "User" si no viene un rol
        };

        await _repository.AddAsync(user);
    }

    public Task<bool> UpdateAsync(UserViewModel userVm)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}