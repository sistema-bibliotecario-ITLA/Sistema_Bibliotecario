using Backend_Biblioteca.Core.Application.ViewModels.User;
using Backend_Biblioteca.Core.Domain.Entities;

namespace Backend_Biblioteca.Core.Application.Interfaces.Services;

public interface IUserService : IGenericService<UserViewModel, SaveUserViewModel>
{
    
}