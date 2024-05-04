using Brah.BL.Dtos.Meta;

namespace Brah.BL.Abstractions;

public interface ISearchResumeTagsService
{
    public Task<List<TagDto>> GetSimilarTags(string? name = null);
}