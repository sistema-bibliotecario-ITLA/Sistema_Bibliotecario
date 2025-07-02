using Backend_Biblioteca.Core.Application.ViewModels.Genre;
using Backend_Biblioteca.Core.Domain.Entities;

namespace Backend_Biblioteca.Core.Application.Interfaces.Services;

public interface IGenreService
{
    Task<IEnumerable<GenreViewModel>> GetAllWithBooks();
    Task<GenreViewModel> GetByIdWithBooks(int id);
    Task<GenreViewModel> GetByNameWithBooks(string name);
    Task AddAsync(SaveGenreViewModel genreVm);
    Task UpdateAsync(GenreViewModel genreVm);
    Task DeleteAsync(int id);
}