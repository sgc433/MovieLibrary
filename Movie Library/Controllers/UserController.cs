
using Microsoft.AspNetCore.Mvc;
using Movie_Library.Contracts.User;
using MovieLibrary.Core.Abstractions;
using MovieLibrary.Core.Models;

namespace Movie_Library.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
    public UserController(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    [HttpGet("getuserbyemail")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var user = await _userService.GetByEmail(email);
        var userResponse = new UserResponse(user.Username, user.Email, user.RegistrationDate);
        return Ok(userResponse);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        await _authService.Register(request.Username, request.Email, request.Password);
        return Ok();
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserRequest request)
    {
        var token = await _authService.Login(request.Email,request.Password);
        return Ok(token);
    }
    [HttpPost("create")]
    public async Task<IActionResult> CreateUser(User user)
    {
        await  _userService.CreateUser(user);
        return Ok();
    }

}