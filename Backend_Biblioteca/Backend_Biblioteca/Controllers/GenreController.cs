using Backend_Biblioteca.Core.Application.Interfaces;
using Backend_Biblioteca.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Biblioteca.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IGenreRepository _repository;
    
    public GenreController(IGenreRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]

    public async Task<IActionResult> GetGenres()
    {
        var genres = await _repository.GetAllAsync();
        return Ok(genres);
    }

    [HttpPost]
    public async Task<IActionResult> AddGenre(Genre genre)
    {
        await _repository.AddAsync(genre);

        if (Response.StatusCode != 201)
            return BadRequest();
        
        return Ok(new {Message = "Genre Added Successfully!"});
    }

    [HttpPut]

    public async Task<IActionResult> UpdateGenre(Genre genre)
    {
        await _repository.Update(genre);
        return Ok(new {Mesage = "Genre Updated"});
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteGenre(int id)
    {
        await _repository.Delete(id);
        return Ok(new {Mesage = "Genre Deleted"});
    }
}