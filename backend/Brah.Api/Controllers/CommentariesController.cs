using Brah.BL.Abstractions;
using Brah.BL.Dtos.Requests.Article;
using Brah.BL.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brah.Api.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class CommentariesController(ICommentaryService commentaryService) : ControllerBase
{
    [HttpPost("new")]
    public async Task<IResult> AddAsync([FromBody] CommentaryRequestDto requestDto)
    {
        try
        {
            await commentaryService.AddCommentaryAsync(User.Identities.Single(), requestDto);
            return Results.Ok();
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
    }
}