using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Dtos.Meta;
using Brah.Data.Abstractions;
using Brah.Data.Models.Tags;
using Microsoft.EntityFrameworkCore;

namespace Brah.BL.Services;

public class SearchArticleTagsService(
    IMapper mapper,
    IRepository<ArticleTag> tagRepository) : ISearchArticleTagsService
{
    public async Task<List<TagDto>> GetSimilarTags(string? name = null)
    {
        const int similarListSize = 10;
        var list = await tagRepository.GetRange()
            .Where(t => name == null || EF.Functions.TrigramsAreSimilar(t.Name, name))
            .Take(similarListSize)
            .ToListAsync();

        return mapper.Map<List<TagDto>>(list);
    }
}