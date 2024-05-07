using System.Security.Claims;
using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Dtos.Requests.Article;
using Brah.BL.Exceptions;
using Brah.Data.Abstractions;
using Brah.Data.Models.Articles;

namespace Brah.BL.Services;

public class CommentaryService(
    IMapper mapper,
    IUserRepository userRepository,
    IRepository<Article> articleRepository,
    IRepository<Commentary> commentaryRepository) : ICommentaryService
{
    public async Task AddCommentaryAsync(
        ClaimsIdentity identity,
        CommentaryRequestDto requestDto)
    {
        var user = await userRepository
            .GetSingleOrDefault(t => t.UserName.Equals(identity.Name));
        var article = await articleRepository
            .GetSingleOrDefault(a => a.Id == requestDto.ArticleId);

        if (user == null || article == null) throw new NotFoundException();

        var commentary = mapper.Map<Commentary>(requestDto);
        commentary.AuthorId = user.Id;
        await commentaryRepository.AddAsync(commentary);
    }
}