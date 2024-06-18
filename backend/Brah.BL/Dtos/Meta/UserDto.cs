using Brah.Data.Enums;

namespace Brah.BL.Dtos.Meta;

public class UserDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string AvatarLink { get; set; } = null!;
    public Role Role { get; set; }
}