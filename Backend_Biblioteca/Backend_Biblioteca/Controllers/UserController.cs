using Backend_Biblioteca.Core.Application.Interfaces.Services;
using Backend_Biblioteca.Core.Application.ViewModels.User;
using Backend_Biblioteca.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Biblioteca.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]

    public async Task<IActionResult> GetUsers()
    {
        var users = await _service.GetAllAsync();
        
        if(users == null)
            return NotFound(new {Message = "there are no users"});

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _service.GetByIdAsync(id);

        if (user == null)
            return NotFound("User not found");
        
        return Ok(user);
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var user = await _service.GetByEmailAsync(email);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] SaveUserViewModel userVm)
    {
        await _service.AddAsync(userVm);
        return Ok(new {Mesage = "User created"});
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UserViewModel userVm)
    {
        await _service.UpdateAsync(userVm);
        return Ok();
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteUser(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}