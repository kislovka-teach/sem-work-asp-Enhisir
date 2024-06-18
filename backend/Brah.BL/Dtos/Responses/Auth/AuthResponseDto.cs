using Brah.BL.Dtos.Meta;

namespace Brah.BL.Dtos.Responses.Auth;

public class AuthResponseDto
{
    public UserThumbnailDto User { get; set; } = null!;
    public string AccessToken { get; set; } = null!;
    public double AccessTokenExpires { get; set; }
    public string RefreshToken { get; set; } = null!;
}