namespace Brah.BL.Dtos.Responses;

public class NotificationResponseDto
{
    public int Id { get; set; }
    public string AuthorAvatarLink { get; set; } = null!;
    public string AuthorUserName { get; set; } = null!;
    public string Text { get; set; } = null!;
}