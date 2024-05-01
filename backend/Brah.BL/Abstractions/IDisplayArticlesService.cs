using Brah.BL.Dtos.Meta;
using Brah.BL.Dtos.Responses.Article;
using Brah.Data.Models.Articles;

namespace Brah.BL.Abstractions;

public interface IDisplayArticlesService
{
    public List<ArticleShortResponseDto> GetAll();

    public Task<List<ArticleShortResponseDto>> GetFiltered(
        string? title = null,
        Topic? topic = null,
        List<TagDto>? tags = null);

    public Task<ArticleFullResponseDto?> GetById(int articleId);
}