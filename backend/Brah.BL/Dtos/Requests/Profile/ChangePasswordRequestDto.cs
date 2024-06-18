using System.ComponentModel.DataAnnotations;

namespace Brah.BL.Dtos.Requests.Profile;

public class ChangePasswordRequestDto
{
    public string OldPassword { get; set; } = null!;
    [Length(6, 64)]
    public string NewPassword { get; set; } = null!;
}