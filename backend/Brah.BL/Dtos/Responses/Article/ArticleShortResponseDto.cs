using Brah.BL.Dtos.Meta;
using Brah.Data.Models.Articles;

namespace Brah.BL.Dtos.Responses.Article;

public class ArticleShortResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public int Karma { get; set; }
    public DateTime TimePosted { get; set; }
    public UserDto Author { get; set; } = null!;
    public Topic Topic { get; set; } = null!;
    public List<TagDto> Tags { get; set; } = null!;
}