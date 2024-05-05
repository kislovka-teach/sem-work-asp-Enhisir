using Brah.BL.Abstractions;
using Brah.BL.Dtos.Requests;
using Brah.BL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Brah.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController(
    IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IResult> Login([FromBody] LoginRequestDto request)
    {
        var response = await authService.LoginAsync(request);
        return response is null ? Results.Unauthorized() : Results.Ok(response);
    }

    [HttpPost("refresh")]
    public IResult Refresh([FromBody] RefreshRequestDto request)
    {
        var response = authService.Refresh(request.RefreshToken);
        return response is null ? Results.Unauthorized() : Results.Ok(response);
    }

    [HttpPost("register")]
    public async Task<IResult> Register([FromBody] RegisterRequestDto request)
    {
        try
        {
            var response = await authService.RegisterAsync(request);
            return Results.Ok(response);
        }
        catch (AlreadyExistsException)
        {
            return Results.ValidationProblem(new Dictionary<string, string[]>
            {
                { "UserName", ["Пользователь с подобным именем уже существует"] }
            });
        }
    }
}