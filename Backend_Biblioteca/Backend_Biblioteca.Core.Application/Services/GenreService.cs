using Backend_Biblioteca.Core.Application.Interfaces;
using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Backend_Biblioteca.Core.Application.ViewModels.Book;
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
        var genres = await _genreRepository.GetAllAsync();

        var genreVm = genres.Select(g => new GenreViewModel
        {
            Id = g.Id,
            GenreName = g.Name,
            Books = g.Books.Select(b => new GenreBook
            {
                Id = b.Id,
                BookName = b.Name
            }).ToList()
        });
        
        return genreVm;
    }

    public async Task<GenreViewModel> GetByIdWithBooks(int id)
    {
        var genre = await _genreRepository.GetByIdAsync(id);

        if (genre == null)
            throw new IndexOutOfRangeException("No se pudo encontrar el genero con este id");

        GenreViewModel genreVm = new();
        genreVm.Id = genre.Id;
        genreVm.GenreName = genre.Name;
        genreVm.Books = genre.Books.Select(b => new GenreBook
        {
            Id = b.Id,
            BookName = b.Name
        }).ToList();
        
        return genreVm;
    }

    public async Task<GenreViewModel> GetByNameWithBooks(string name)
    {
        var genre = await _genreRepository.GetByNameAsync(name);

        if (genre == null)
            throw new NullReferenceException("Este genero no existe");

        GenreViewModel genreVm = new();
        genreVm.Id = genre.Id;
        genreVm.GenreName = genre.Name;
        genreVm.Books = genre.Books.Select(b => new GenreBook
        {
            Id = b.Id,
            BookName = b.Name
        }).ToList();
        
        return genreVm;
    }

    public async Task AddAsync(SaveGenreViewModel genreVm)
    {
        Genre genre = new();
        genre.Name = genreVm.GenreName;
        
        await _genreRepository.AddAsync(genre);
    }

    public async Task UpdateAsync(GenreViewModel genreVm)
    {
        Genre genre = new();
        genre.Id = genreVm.Id;
        genre.Name = genreVm.GenreName;
        
        await _genreRepository.Update(genre);
    }

    public async Task DeleteAsync(int id)
    {
        await _genreRepository.Delete(id);
    }
}