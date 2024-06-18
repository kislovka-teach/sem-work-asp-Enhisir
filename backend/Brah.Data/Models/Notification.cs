namespace Brah.Data.Models;

public class Notification
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public User Author { get; set; } = null!;
    public string Text { get; set; } = null!;
}