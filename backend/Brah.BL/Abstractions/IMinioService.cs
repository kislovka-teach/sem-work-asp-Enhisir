using Microsoft.AspNetCore.Http;

namespace Brah.BL.Abstractions;

public interface IMinioService
{
    public Task<string> GetImageAsync(string imageId);
    public Task<string> SaveImage(IFormFile image);
    public Task DeleteImage(string imageId);
}