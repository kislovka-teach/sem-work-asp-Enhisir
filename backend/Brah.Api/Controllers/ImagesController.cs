using Brah.BL.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Brah.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagesController(IMinioService minioService) : ControllerBase
{
    [HttpGet("{imageId}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IResult> GetImage(string imageId)
    {
        try
        {
            var url = await minioService.GetImageAsync(imageId);
            return Results.Redirect(url);
        }
        catch (Exception)
        {
            return Results.NotFound();
        }
    }

    [HttpPost("post_image")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IResult> GetImage(IFormFile image)
    {
        var imageId = await minioService.SaveImage(image);
        return Results.Ok(imageId);
    }
}