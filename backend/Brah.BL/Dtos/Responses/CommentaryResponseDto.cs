using Brah.BL.Dtos.Meta;

namespace Brah.BL.Dtos.Responses;

public class CommentaryResponseDto
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public DateTime TimePosted { get; set; }
    public int? ParentId { get; set; }
    public int AuthorId { get; set; }
    public int ArticleId { get; set; }
    public UserDto Author { get; set; } = null!;
    public List<CommentaryResponseDto> Children { get; set; } = null!;
}