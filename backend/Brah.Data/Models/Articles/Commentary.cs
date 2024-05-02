namespace Brah.Data.Models.Articles;

public class Commentary
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public DateTime TimePosted { get; set; }

    public int ArticleId { get; set; }
    public Article Article { get; set; } = null!;

    public int? ParentId { get; set; }
    public Commentary? Parent { get; set; }

    public int AuthorId { get; set; }
    public User Author { get; set; } = null!;

    public List<Commentary> Children { get; set; } = null!;
}