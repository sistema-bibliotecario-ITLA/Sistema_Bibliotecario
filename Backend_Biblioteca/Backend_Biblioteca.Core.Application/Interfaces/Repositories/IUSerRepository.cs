using Backend_Biblioteca.Core.Application.DTO;
using Backend_Biblioteca.Core.Domain.Entities;

namespace Backend_Biblioteca.Core.Application.Interfaces.Repositories;

public interface IUSerRepository : IGenericRepository<User>
{
    Task<User> GetByEmail(string email);
}