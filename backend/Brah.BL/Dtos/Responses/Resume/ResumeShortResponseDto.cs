using Brah.Data.Enums;

namespace Brah.BL.Dtos.Responses.Resume;

public class ResumeShortResponseDto
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
}