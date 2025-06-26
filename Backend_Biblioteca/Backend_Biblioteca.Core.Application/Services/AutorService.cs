using Backend_Biblioteca.Core.Application.Interfaces.Repositories;
using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Backend_Biblioteca.Core.Application.ViewModels.Autor;
using Backend_Biblioteca.Core.Application.ViewModels.Book;
using Backend_Biblioteca.Core.Domain.Entities;

namespace Backend_Biblioteca.Core.Application.Services;

public class AutorService : IAutorService 
{
    private readonly IAutorRepository _autorRepository;

    public AutorService(IAutorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }

    public async Task<IEnumerable<AutorViewModel>> GetAllWithBooks()
    {
        var authors = await _autorRepository.GetAllAsync();

        var authorsVm = authors.Select(a => new AutorViewModel
        {
            Id = a.Id,
            AutorName = a.Name,
            Books = a.Books.Select(b => new AuthorBook
            {
                Id = b.Id,
                Name = b.Name,
                GenreBookName = b.Genre?.Name,
                ImgUrl = b.ImgUrl
            }).ToList()

        });

        return authorsVm;
    }

    public async Task<AutorViewModel> GetByIdWithBooks(int id)
    {
        var author = await _autorRepository.GetWithBooks(id);

        if (author == null)
            throw new NullReferenceException("Author not found");

        AutorViewModel authorVm = new();
        authorVm.Id = author.Id;
        authorVm.AutorName = author.Name;
        authorVm.Books = author.Books.Select(b => new AuthorBook
        {
            Id = b.Id,
            Name = b.Name,
            GenreBookName = b.Genre?.Name,
            ImgUrl = b.ImgUrl
        }).ToList();
        
        return authorVm;
    }

    public async Task Create(SaveAutorViewModel autorVm)
    {
        Author author = new();
        author.Name = autorVm.AutorName;
        
        await _autorRepository.AddAsync(author);
    }

    public async Task Update(AutorViewModel autorVm)
    {
        Author author = await _autorRepository.GetWithBooks(autorVm.Id);
        if (author == null)
            throw new NullReferenceException("Author not found");
        
        author.Id = autorVm.Id;
        author.Name = autorVm.AutorName;
        
        await _autorRepository.Update(author);
    }

    public async Task Delete(int id)
    {
        await _autorRepository.Delete(id);
    }
}