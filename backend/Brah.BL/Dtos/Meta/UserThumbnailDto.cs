using Brah.Data.Enums;

namespace Brah.BL.Dtos.Meta;

public class UserThumbnailDto
{
    public string UserName { get; set; } = null!;
    public Role Role { get; set; }
}