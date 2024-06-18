using Brah.BL.Abstractions;
using Brah.BL.Dtos.Requests.Profile;
using Brah.BL.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brah.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProfileController(
    IDisplayProfileService displayProfileService,
    IEditProfileService editProfileService) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            var profileResponseDto =
                await displayProfileService
                    .GetByUserName(User.Identity!.Name!);
            return Results.Ok(profileResponseDto);
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
    }

    [HttpPatch("edit")]
    public async Task<IResult> EditProfile([FromBody] EditProfileRequestDto requestDto)
    {
        try
        {
            await editProfileService.EditProfile(User.Identities.Single(), requestDto);
            return Results.Ok();
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
    }

    [HttpPost("change_password")]
    public async Task<IResult> ChangePassword([FromBody] ChangePasswordRequestDto requestDto)
    {
        try
        {
            await editProfileService.ChangePassword(User.Identities.Single(), requestDto);
            return Results.Ok();
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
        catch (InvalidPasswordException)
        {
            return Results.BadRequest();
        }
    }

    [HttpPost("update_image")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IResult> UpdateImage(IFormFile image)
    {
        await editProfileService
            .UpdateImage(User.Identities.Single(), image);
        return Results.Ok();
    }
}