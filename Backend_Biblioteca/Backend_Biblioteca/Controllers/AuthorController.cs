using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Backend_Biblioteca.Core.Application.ViewModels.Autor;
using Backend_Biblioteca.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Biblioteca.Controllers;

[Route("api/author")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAutorService _autorService;

    public AuthorController(IAutorService autorService)
    {
        _autorService = autorService;
    }

    //[Authorize(Roles = "Client, Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
        var authors = await _autorService.GetAllWithBooks();
        return Ok(authors);
    }

    //[Authorize(Roles = "Client, Admin")]
    [HttpGet("{id:int}")]

    public async Task<IActionResult> GetAuthorById(int id)
    {
        var author = await _autorService.GetByIdWithBooks(id);
        return Ok(author);
    }

    //[Authorize(Roles = "Client, Admin")]
    [HttpGet("{authorName}")]
    public async Task<IActionResult> GetAuthorByName(string authorName)
    {
        var author =  await _autorService.GetAuthorByName(authorName);
        return Ok(author);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]

    public async Task PostAuthor(SaveAutorViewModel author)
    {
        await _autorService.Create(author);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]

    public async Task PutAuthor(AutorViewModel author)
    {
        await _autorService.Update(author);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]

    public async Task DeleteAuthor(int id)
    {
        await _autorService.Delete(id);
    }
}