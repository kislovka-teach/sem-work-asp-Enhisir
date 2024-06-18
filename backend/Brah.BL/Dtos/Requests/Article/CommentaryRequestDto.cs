namespace Brah.BL.Dtos.Requests.Article;

public class CommentaryRequestDto
{
    public int ArticleId { get; set; }
    public int? ParentId { get; set; }
    public string Text { get; set; } = null!;
}