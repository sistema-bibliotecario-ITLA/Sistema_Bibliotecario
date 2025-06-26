using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Backend_Biblioteca.Core.Application.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Biblioteca.Controllers;

[Route("api/{controller}")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpGet]

    public async Task<ActionResult<List<BookViewModel>>> GetAllBooks()
    {
        var books = await _bookService.GetAllBooks();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookViewModel>> GetBook(int id)
    {
        var book = await _bookService.GetBookById(id);
        return Ok(book);
    }
}