using Brah.BL.Dtos.Meta;
using Brah.BL.Dtos.Requests.Resume;

namespace Brah.BL.Abstractions;

public interface ITagsService
{
    public Task<List<TagDto>> GetSimilarArticleTags(string? name = null);
    public Task<List<TagDto>> GetSimilarResumeTags(string? name = null);
    public Task<TagDto> AddResumeTag(CreateTagDto tag);
    public Task<TagDto> AddArticleTag(CreateTagDto tag);
}