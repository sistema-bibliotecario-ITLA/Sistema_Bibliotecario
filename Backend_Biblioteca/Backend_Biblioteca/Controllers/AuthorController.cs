using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Biblioteca.Controllers;

[Route("api/{controller}")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAutorService _autorService;

    public AuthorController(IAutorService autorService)
    {
        _autorService = autorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
        var authors = await _autorService.GetAllWithBooks();
        return Ok(authors);
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetAuthorById(int id)
    {
        var author = await _autorService.GetByIdWithBooks(id);
        return Ok(author);
    }
}