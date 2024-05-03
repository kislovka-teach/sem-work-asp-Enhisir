using Brah.BL.Dtos.Meta;
using Brah.BL.Dtos.Responses.Article;

namespace Brah.BL.Dtos.Responses;

public class ProfileResponseDto
{
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string AvatarLink { get; set; } = null!;
    
    public List<ArticleShortResponseDto> Articles { get; set; } = null!;
}