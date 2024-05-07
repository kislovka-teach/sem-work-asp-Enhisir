using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Dtos.Meta;
using Brah.BL.Dtos.Requests.Resume;
using Brah.BL.Exceptions;
using Brah.Data.Abstractions;
using Brah.Data.Models.Tags;
using Microsoft.EntityFrameworkCore;

namespace Brah.BL.Services;

public class TagsService(
    IMapper mapper,
    IRepository<ArticleTag> articleTagRepository,
    IRepository<ResumeTag> resumeTagRepository) : ITagsService
{
    public async Task<List<TagDto>> GetSimilarArticleTags(string? name = null)
    {
        const int similarListSize = 10;
        var list = await articleTagRepository.GetRange()
            .Where(t => name == null || EF.Functions.TrigramsAreSimilar(t.Name, name))
            .Take(similarListSize)
            .ToListAsync();

        return mapper.Map<List<TagDto>>(list);
    }

    public async Task<TagDto> AddArticleTag(CreateTagDto tag)
    {
        var existingTag = await articleTagRepository
            .GetSingleOrDefault(t => t.Name.ToLower().Equals(tag.Name));

        if (existingTag is not null) throw new AlreadyExistsException();
        
        var newTag = mapper.Map<ArticleTag>(tag);
         return mapper.Map<TagDto>(await articleTagRepository.AddAsync(newTag));
    }

    public async Task<List<TagDto>> GetSimilarResumeTags(string? name = null)
    {
        const int similarListSize = 10;
        var list = await resumeTagRepository.GetRange()
            .Where(t => name == null || EF.Functions.TrigramsAreSimilar(t.Name, name))
            .Take(similarListSize)
            .ToListAsync();

        return mapper.Map<List<TagDto>>(list);
    }
    
    public async Task<TagDto> AddResumeTag(CreateTagDto tag)
    {
        var existingTag = await resumeTagRepository
            .GetSingleOrDefault(t => t.Name.ToLower().Equals(tag.Name));

        if (existingTag is not null) throw new AlreadyExistsException();
        
        var newTag = mapper.Map<ResumeTag>(tag);
        return mapper.Map<TagDto>(await resumeTagRepository.AddAsync(newTag));
    }
}