using System.ComponentModel.DataAnnotations;
using Brah.Data.Enums;
using Brah.Data.Models.Articles;
using Brah.Data.Models.Resumes;

namespace Brah.Data.Models;

public class User
{
    public int Id { get; set; }

    [MaxLength(200)]
    public string UserName { get; set; } = null!;

    [MaxLength(200)]
    public string FirstName { get; set; } = null!;

    [MaxLength(200)]
    public string LastName { get; set; } = null!;

    [MaxLength(2000)]
    public string? AvatarLink { get; set; } = null!;

    [MaxLength(256)]
    public string PasswordHashed { get; set; } = null!;

    public List<Article> Articles { get; set; } = null!;

    public Resume? Resume { get; set; }

    public Role Role { get; set; }
}