using Backend_Biblioteca.Core.Application.ViewModels.Book;

namespace Backend_Biblioteca.Core.Application.Interfaces.Services;

public interface IBookService
{
    Task<IEnumerable<BookViewModel>> GetAllBooks();
    Task<BookViewModel> GetBookById(int id);
    Task AddNewBook(SaveBookViewModel model);
    Task UpdateBook(BookViewModel model);
    Task DeleteBook(int id);
    Task<BookViewModel> GetBookByName(string name);
}