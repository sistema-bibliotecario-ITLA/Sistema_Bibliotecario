using System.Collections;
using Backend_Biblioteca.Core.Domain.Entities;

namespace Backend_Biblioteca.Core.Application.Interfaces.Repositories;

public interface IAutorRepository : IGenericRepository<Author>
{
    Task<Author> GetWithBooks(int id);
}