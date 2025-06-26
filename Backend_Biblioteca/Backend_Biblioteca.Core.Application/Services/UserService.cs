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
    public async Task<IEnumerable<UserViewModel>> GetAllUsers()
    {
        var users = await _repository.GetAll();
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

    public async Task<UserViewModel> GetUser(int id)
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

    public async Task AddUser(SaveUserViewModel userVm)
    {
        User user = new();
        user.Email = userVm.Email;
        user.Name = userVm.Name;
        user.PasswordHash = _passwordHasher.HashPassword(userVm.Password);
        user.Role = userVm.Role;

        await _repository.CreateAsync(user);
    }

    public async Task UpdateUser(UserViewModel userVm)
    {
        User user = await _repository.GetByIdAsync(userVm.Id);

        if (user == null)
            throw new IndexOutOfRangeException("User not found");
        
        userVm.Id = user.Id;
        userVm.Email = user.Email;
        userVm.Name = user.Name;
        userVm.Role = user.Role;
        
        await _repository.UpdateAsync(user);
    }


    public async Task DeleteUser(int id)
    {
        await _repository.DeleteAsync(id);
    }
}