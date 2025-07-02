using Backend_Biblioteca.Core.Application.Interfaces.Repositories;
using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Backend_Biblioteca.Core.Application.ViewModels.Book;
using Backend_Biblioteca.Core.Domain.Entities;

namespace Backend_Biblioteca.Core.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<IEnumerable<BookViewModel>> GetAllBooks()
    {
        var books = await _bookRepository.GetAllAsync();

        var booksVm = books.Select(b => new BookViewModel
        {
            Id = b.Id,
            Name = b.Name,
            IsAvailable = b.IsAvailable,
            Quantity = b.Quantity,
            GenreName = b.Genre.Name,
            AuthorName = b.Author.Name,
            ImgUrl = b.ImgUrl,
            RentPrice = b.RentPrice,
            Description = b.Description,
        }).ToList();
        
        return booksVm;
    }

    public async Task<BookViewModel> GetBookById(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        
        if(book == null)
            throw new NullReferenceException("Book not found");

        BookViewModel bookVm = new();
        bookVm.Id = book.Id;
        bookVm.Name = book.Name;
        bookVm.IsAvailable = book.IsAvailable;
        bookVm.Quantity = book.Quantity;
        bookVm.GenreName = book.Genre.Name;
        bookVm.AuthorName = book.Author.Name;
        bookVm.ImgUrl = book.ImgUrl;
        bookVm.RentPrice = book.RentPrice;
        bookVm.Description = book.Description;
        
        return bookVm;
    }

    public async Task AddNewBook(SaveBookViewModel model)
    {
        Book book = new();
        book.Name = model.BookName;
        book.IsAvailable = model.IsAvailable;
        book.Quantity = model.Quantity;
        book.Author.Name = model.AuthorName;
        book.Genre.Name = model.GenreName;
        book.Description = model.Description;
        book.RentPrice = model.RentPrice;
        
        await _bookRepository.AddAsync(book);
    }

    public async Task UpdateBook(BookViewModel model)
    {
        var book = await _bookRepository.GetByIdAsync(model.Id);
        
        if(book == null)
            throw new NullReferenceException("Book not found");
        
        book.Id = model.Id;
        book.Name = model.Name;
        book.IsAvailable = model.IsAvailable;
        book.Quantity = model.Quantity;
        book.Author.Name = model.AuthorName;
        book.Genre.Name = model.GenreName;
        book.Quantity = model.Quantity;
        book.ImgUrl = model.ImgUrl;
        book.RentPrice = model.RentPrice;
        book.Description = model.Description;
    }

    public async Task DeleteBook(int id)
    {
        await _bookRepository.Delete(id);
    }

    public async Task<BookViewModel> GetBookByName(string name)
    {
        var book = await _bookRepository.FindByName(name);
        
        if(book == null)
            throw new NullReferenceException("Book not found");

        BookViewModel bookVm = new();
        bookVm.Id = book.Id;
        bookVm.Name = book.Name;
        bookVm.IsAvailable = book.IsAvailable;
        bookVm.Quantity = book.Quantity;
        bookVm.GenreName = book.Genre.Name;
        bookVm.AuthorName = book.Author.Name;
        bookVm.ImgUrl = book.ImgUrl;
        bookVm.RentPrice = book.RentPrice;
        bookVm.Description = book.Description;
        
        return bookVm;
    }
}