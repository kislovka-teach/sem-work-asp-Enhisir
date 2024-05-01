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
    public List<ArticleShortResponseDto> GetAll()
    {
        var query = articleRepository.GetRange();
        return mapper.Map<List<ArticleShortResponseDto>>(query);
    }

    public async Task<List<ArticleShortResponseDto>> GetFiltered(
        string? title = null,
        Topic? topic = null,
        List<TagDto>? tags = null)
    {
        var query = await articleRepository.GetRange()
            .Where(x => title == null || EF.Functions.ToTsVector(x.Title).Matches(title))
            .Where(x => topic == null || x.TopicId == topic.Id)
            .Where(x => tags == null || tags.Count == 0 ||
                        tags.Select(t => t.Id).Order()
                            .SequenceEqual(x.Tags.Select(t => t.Id).Order()))
            .ToListAsync();

        return mapper.Map<List<ArticleShortResponseDto>>(query);
    }

    public async Task<ArticleFullResponseDto?> GetById(int id)
    {
        var article = await articleRepository
            .GetSingleOrDefault(t => t.Id == id);
        return mapper.Map<ArticleFullResponseDto>(article);
    }
}