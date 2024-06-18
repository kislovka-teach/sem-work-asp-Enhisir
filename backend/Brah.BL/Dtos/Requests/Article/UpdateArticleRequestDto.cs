using Brah.BL.Dtos.Meta;

namespace Brah.BL.Dtos.Requests.Article;

public class UpdateArticleRequestDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public int TopicId { get; set; }

    public List<TagDto> Tags { get; set; } = null!;
}