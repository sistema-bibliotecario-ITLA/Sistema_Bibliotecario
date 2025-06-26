using Backend_Biblioteca.Core.Application.Interfaces;
using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Backend_Biblioteca.Core.Application.ViewModels.Genre;
using Backend_Biblioteca.Core.Domain.Entities;

namespace Backend_Biblioteca.Core.Application.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<GenreViewModel>> GetAllWithBooks()
    {
        throw new NotImplementedException();
    }

    public async Task<GenreViewModel> GetByIdWithBooks(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<GenreViewModel> GetByNameWithBooks(string name)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(SaveGenreViewModel genreVm)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(GenreViewModel genreVm)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}