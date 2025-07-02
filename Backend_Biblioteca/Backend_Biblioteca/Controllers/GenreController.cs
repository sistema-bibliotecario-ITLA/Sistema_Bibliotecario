using Backend_Biblioteca.Core.Application.Interfaces;
using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Backend_Biblioteca.Core.Application.ViewModels.Genre;
using Backend_Biblioteca.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Biblioteca.Controllers;

[Route("api/genre")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;
    
    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }
    
    //[Authorize(Roles = "Client, Admin")]
    [HttpGet]

    public async Task<IActionResult> GetGenres()
    {
        var genres = await _genreService.GetAllWithBooks();
        return Ok(genres);
    }
    
    //[Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AddGenre(SaveGenreViewModel genre)
    {
        await _genreService.AddAsync(genre);

        if (Response.StatusCode != 201)
            return BadRequest();
        
        return Ok(new {Message = "Genre Added Successfully!"});
    }

    //[Authorize(Roles = "Admin")]
    [HttpPut]

    public async Task<IActionResult> UpdateGenre(GenreViewModel genre)
    {
        await _genreService.UpdateAsync(genre);
        return Ok(new {Mesage = "Genre Updated"});
    }

    //[Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteGenre(int id)
    {
        await _genreService.DeleteAsync(id);
        return Ok(new {Mesage = "Genre Deleted"});
    }
}