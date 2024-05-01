using Brah.Data.Models.Tags;

namespace Brah.Data.Models.Articles;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public int Karma { get; set; }
    public DateTime TimePosted { get; set; }
    
    public int AuthorId { get; set; }
    public User Author { get; set; } = null!;

    public Topic Topic { get; set; } = null!;
    
    public List<ArticleTag> Tags { get; set; } = null!;

    public List<Commentary> Commentaries { get; set; } = null!;
}