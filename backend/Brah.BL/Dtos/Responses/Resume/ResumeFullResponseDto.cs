using Brah.BL.Dtos.Meta;
using Brah.Data.Enums;
namespace Brah.BL.Dtos.Responses.Resume;

public class ResumeFullResponseDto
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string AvatarLink { get; set; } = null!;

    public string Profession { get; set; } = null!;
    public bool LookingForWork { get; set; }
    public int LeftSalaryBorder { get; set; }
    public int RightSalaryBorder { get; set; }
    public Grade Grade { get; set; }

    public List<TagDto> Tags { get; set; } = null!;

    public List<WorkPlaceDto> WorkPlaces { get; set; } = null!;

    public string About { get; set; } = null!;
}
