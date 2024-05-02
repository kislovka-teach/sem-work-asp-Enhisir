using System.ComponentModel.DataAnnotations;

namespace Brah.BL.Dtos.Requests;

public class RegisterRequestDto
{
    [Required]
    [MaxLength(200)]
    public string UserName { get; set; } = null!;
    
    [Required]
    [MaxLength(200)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [MaxLength(200)]
    public string LastName { get; set; } = null!;
    
    [Required]
    [MaxLength(64)]
    public string Password { get; set; } = null!;
}