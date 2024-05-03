using Brah.BL.Dtos.Meta;
using Brah.BL.Dtos.Responses.Article;
using Brah.Data.Models.Articles;

namespace Brah.BL.Abstractions;

public interface IDisplayArticlesService
{
    public Task<List<ArticleShortResponseDto>> GetRange(
        string? title = null,
        Topic? topic = null,
        int[]? tags = null,
        int? skip = null,
        int? take = null);

    public Task<ArticleFullResponseDto?> GetById(int articleId);

    public Task<List<ArticleThumbnailResponseDto>> GetTop();
}