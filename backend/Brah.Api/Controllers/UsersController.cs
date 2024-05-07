using Brah.BL.Abstractions;
using Brah.BL.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brah.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController(
    IDisplayProfileService displayProfileService,
    ISubscriptionService subscriptionService) : ControllerBase
{
    [HttpGet("{userName}")]
    public async Task<IResult> GetByUserName(string userName)
    {
        try
        {
            var profileResponseDto =
                await displayProfileService
                    .GetByUserName(userName, User.Identities.FirstOrDefault());
            return Results.Ok(profileResponseDto);
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
    }
    
    [HttpPost("{userName}/subscribe")]
    [Authorize]
    public async Task<IResult> Subscribe(string userName)
    {
        try
        {
            await subscriptionService
                .Subscribe(User.Identities.Single(), userName);
            return Results.Ok();
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
        catch (ForbiddenException)
        {
            return Results.Forbid();
        }
    }
    
    [HttpDelete("{userName}/unsubscribe")]
    [Authorize]
    public async Task<IResult> Unsubscribe(string userName)
    {
        try
        {
            await subscriptionService
                .Unsubscribe(User.Identities.Single(), userName);
            return Results.Ok();
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
        catch (ForbiddenException)
        {
            return Results.Forbid();
        }
    }
}