using System.ComponentModel.DataAnnotations;
using Brah.Data.Enums;
using Brah.Data.Models.Tags;

namespace Brah.BL.Dtos.Requests.Resume;

public class CreateResumeRequestDto
{
    [Url]
    [MaxLength(64)]
    public string? Telegram { get; set; }

    [EmailAddress]
    [MaxLength(320)]
    public string? Email { get; set; }

    [MaxLength(200)]
    public string Profession { get; set; } = null!;
    public bool LookingForWork { get; set; }
    public int LeftSalaryBorder { get; set; }
    public int RightSalaryBorder { get; set; }
    public Grade Grade { get; set; }

    [MaxLength(2000)]
    public string About { get; set; } = null!;

    public List<ResumeTag> Tags { get; set; } = null!;

    public List<CreateWorkPlaceDto> WorkPlaces { get; set; } = null!;
}