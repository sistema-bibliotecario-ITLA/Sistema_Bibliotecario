using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Backend_Biblioteca.Core.Application.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
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
    
    [Authorize(Roles = "Client")]
    [HttpGet]

    public async Task<ActionResult<List<BookViewModel>>> GetAllBooks()
    {
        var books = await _bookService.GetAllBooks();
        return Ok(books);
    }
    [Authorize(Roles = "Client")]
    [HttpGet("{id}")]
    public async Task<ActionResult<BookViewModel>> GetBook(int id)
    {
        var book = await _bookService.GetBookById(id);
        return Ok(book);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody]SaveBookViewModel book)
    {
        await _bookService.AddNewBook(book);
        return Ok(new {message = "the book has been added"});
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]

    public async Task<IActionResult> UpdateBook([FromBody] BookViewModel book)
    {
        await _bookService.UpdateBook(book);
        return Ok(new {message = "the book has been upated"});
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete]

    public async Task<IActionResult> DeleteBook(int id)
    {
        await _bookService.DeleteBook(id);
        return Ok(new {message = "the book has been deleted"});
    }
}