using Brah.Data.Enums;

namespace Brah.Data.Models.Resumes;

public class WorkPlace
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string Profession { get; set; } = null!;
    public Grade Grade { get; set; }
    public string Description { get; set; } = null!;
    public DateTime DateBegin { get; set; }
    public DateTime? DateEnd { get; set; }

    public int ResumeId { get; set; }
    public Resume Resume { get; set; } = null!;
}