using System.ComponentModel.DataAnnotations;

namespace Brah.BL.Dtos.Requests.Auth;

public class LoginRequestDto
{
    [Required]
    [MaxLength(200)]
    public string UserName { get; set; } = null!;

    [Required]
    [MaxLength(64)]
    public string Password { get; set; } = null!;
}