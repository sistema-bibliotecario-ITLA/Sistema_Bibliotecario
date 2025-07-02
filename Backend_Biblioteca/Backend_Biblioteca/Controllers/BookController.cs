using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Backend_Biblioteca.Core.Application.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Biblioteca.Controllers;

[Route("api/book")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    //[Authorize(Roles = "Client, Admin")]
    [HttpGet]

    public async Task<ActionResult<List<BookViewModel>>> GetAllBooks()
    {
        var books = await _bookService.GetAllBooks();
        return Ok(books);
    }
    
    //[Authorize(Roles = "Client, Admin")]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookViewModel>> GetBook(int id)
    {
        var book = await _bookService.GetBookById(id);
        return Ok(book);
    }
    
    //[Authorize(Roles = "Client, Admin")]
    [HttpGet("{name}")]
    public async Task<IActionResult> GetBookByName(string name)
    {
        var book = await _bookService.GetBookByName(name);
        return Ok(book);
    }

    //[Authorize(Roles = "Admin")]
    [HttpPost]

    public async Task CreateBook([FromBody] SaveBookViewModel book)
    {
        await _bookService.AddNewBook(book);
    }

    //[Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task UpdateBook([FromBody] BookViewModel book)
    {
        await _bookService.UpdateBook(book);
    }

    //[Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]

    public async Task DeleteBook(int id)
    {
        await _bookService.DeleteBook(id);
    }
}