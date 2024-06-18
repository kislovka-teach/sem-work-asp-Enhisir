using System.Security.Claims;
using Brah.BL.Dtos.Requests.Article;

namespace Brah.BL.Abstractions;

public interface IManageArticleService
{
    public Task CreateArticleAsync(
        ClaimsIdentity identity,
        CreateArticleRequestDto requestDto);

    public Task UpdateArticleAsync(
        ClaimsIdentity identity,
        UpdateArticleRequestDto requestDto);

    // public Task UpdateKarma()
}