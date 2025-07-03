using Backend_Biblioteca.Core.Application.Services;
using Backend_Biblioteca.Core.Application.ViewModels.User;
using Backend_Biblioteca.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Backend_Biblioteca.Controllers;

[Route("api/login")]
[AllowAnonymous] // cualquiera puede acceder a este endpoint ya que es para loguearse
[ApiController]
public class LoginController : ControllerBase
{
    private readonly UserViewModel _userVm;
    private readonly LoginService _loginService;
    public LoginController(LoginService loginService)
    {
        _loginService = loginService;
        _userVm = new UserViewModel();
    }
    //esto es el metodo para que el usuario se loguee y reciva su token
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginViewModel loginVm)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _loginService.LoginAsync(loginVm);
        if(!result.IsSuccess)
            return Unauthorized(new {message = result.Message});
        
        return Ok(new {token = result.Token, userVm = result.UserVm});
    }
    
}