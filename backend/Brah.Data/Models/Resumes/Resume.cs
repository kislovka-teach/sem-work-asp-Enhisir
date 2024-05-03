using System.ComponentModel.DataAnnotations;
using Brah.Data.Enums;
using Brah.Data.Models.Tags;

namespace Brah.Data.Models.Resumes;

public class Resume
{
    public int Id { get; set; }

    [MaxLength(200)]
    public string Profession { get; set; } = null!;
    public bool LookingForWork { get; set; }
    public int LeftSalaryBorder { get; set; }
    public int RightSalaryBorder { get; set; }
    public Grade Grade { get; set; }

    [MaxLength(2000)]
    public string About { get; set; } = null!;

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public List<ResumeTag> Tags { get; set; } = null!;

    public List<WorkPlace> WorkPlaces { get; set; } = null!;
}