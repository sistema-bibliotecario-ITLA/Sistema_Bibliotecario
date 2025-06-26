using Backend_Biblioteca.Core.Application.ViewModels.User;
using Backend_Biblioteca.Core.Domain.Entities;

namespace Backend_Biblioteca.Core.Application.Interfaces.Services;

public interface IUserService
{
    Task<IEnumerable<UserViewModel>> GetAllUsers();
    Task<UserViewModel> GetUser(int id);
    Task AddUser(SaveUserViewModel userVm);
    Task UpdateUser(UserViewModel userVm);
    Task DeleteUser(int id);
}