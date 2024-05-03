using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Dtos.Meta;
using Brah.BL.Dtos.Responses.Article;
using Brah.Data.Abstractions;
using Brah.Data.Models.Articles;
using Microsoft.EntityFrameworkCore;

namespace Brah.BL.Services;

public class DisplayArticlesService(
    IMapper mapper,
    IRepository<Article> articleRepository)
    : IDisplayArticlesService
{
    public async Task<List<ArticleShortResponseDto>> GetRange(
        string? title = null,
        Topic? topic = null,
        List<TagDto>? tags = null,
        int? skip = null,
        int? take = null)
    {
        var query = articleRepository.GetRange()
            .Where(x => title == null || EF.Functions.ToTsVector(x.Title).Matches(title))
            .Where(x => topic == null || x.TopicId == topic.Id)
            .Where(x => tags == null || tags.Count == 0 ||
                        tags.Select(t => t.Id).Order()
                            .SequenceEqual(x.Tags.Select(t => t.Id).Order()));
        var pageArticleList = await GetSlice(query, skip, take).ToListAsync();

        return mapper.Map<List<ArticleShortResponseDto>>(pageArticleList);
    }

    public async Task<ArticleFullResponseDto?> GetById(int id)
    {
        var article = await articleRepository
            .GetSingleOrDefault(t => t.Id == id);
        return mapper.Map<ArticleFullResponseDto>(article);
    }

    public async Task<List<ArticleThumbnailResponseDto>> GetTop()
    {
        const int topSize = 10;

        var top = await articleRepository.GetRange()
            .Where(x => x.TimePosted.ToUniversalTime() >= DateTime.Now.ToUniversalTime().AddMonths(-1))
            .OrderByDescending(x => x.Karma)
            .Take(topSize)
            .ToListAsync();
        
        return mapper.Map<List<ArticleThumbnailResponseDto>>(top);
    }

    private static IQueryable<Article> GetSlice(
        IQueryable<Article> query,
        int? skip = null,
        int? take = null)
    {
        if (skip is not null) query = query.Skip(skip.Value);
        if (take is not null) query = query.Take(take.Value);
        return query;
    }
}