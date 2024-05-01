using System.ComponentModel.DataAnnotations;
using Brah.Data.Models.Articles;
using Brah.Data.Models.Resumes;

namespace Brah.Data.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string AvatarLink { get; set; } = null!;
    public string PasswordHashed { get; set; } = null!;

    public List<Article> Articles { get; set; } = null!;

    public int ResumeId { get; set; }
    public Resume? Resume { get; set; } = null!;
}