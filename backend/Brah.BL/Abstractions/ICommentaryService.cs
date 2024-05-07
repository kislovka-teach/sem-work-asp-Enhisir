using System.Security.Claims;
using Brah.BL.Dtos.Requests.Article;

namespace Brah.BL.Abstractions;

public interface ICommentaryService
{
    public Task AddCommentaryAsync(
        ClaimsIdentity identity,
        CommentaryRequestDto requestDto);
}