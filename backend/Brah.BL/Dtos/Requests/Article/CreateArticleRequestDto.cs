using Brah.BL.Dtos.Meta;

namespace Brah.BL.Dtos.Requests.Article;

public class CreateArticleRequestDto
{
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public int TopicId { get; set; }

    public List<TagDto> Tags { get; set; } = null!;
}