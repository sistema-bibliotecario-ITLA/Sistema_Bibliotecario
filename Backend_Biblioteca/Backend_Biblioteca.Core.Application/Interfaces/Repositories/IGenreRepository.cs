using Backend_Biblioteca.Core.Application.Interfaces.Repositories;
using Backend_Biblioteca.Core.Domain.Entities;

namespace Backend_Biblioteca.Core.Application.Interfaces;

public interface IGenreRepository : IGenericRepository<Genre>
{
    Task<Genre> GetByNameAsync(string name);
}