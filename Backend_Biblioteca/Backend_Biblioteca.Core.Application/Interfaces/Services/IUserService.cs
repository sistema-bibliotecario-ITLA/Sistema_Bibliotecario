using Backend_Biblioteca.Core.Application.ViewModels.User;
using Backend_Biblioteca.Core.Domain.Entities;

namespace Backend_Biblioteca.Core.Application.Interfaces.Services;

public interface IUserService
{
    Task<IEnumerable<UserViewModel>> GetAllAsync();
    Task<UserViewModel> GetByIdAsync(int id);
    Task<UserViewModel> GetByEmailAsync(string email);
    Task AddAsync(SaveUserViewModel userVm);
    Task<bool> UpdateAsync(UserViewModel userVm);
    Task<bool> DeleteAsync(int id);
}