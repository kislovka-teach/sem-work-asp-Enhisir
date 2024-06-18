using Brah.Data.Enums;

namespace Brah.BL.Dtos.Meta;

public class WorkPlaceDto
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string Profession { get; set; } = null!;
    public Grade Grade { get; set; }
    public string Description { get; set; } = null!;
    public string DateBegin { get; set; } = null!;
    public string? DateEnd { get; set; }
}