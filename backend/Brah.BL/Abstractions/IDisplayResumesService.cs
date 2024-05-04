using Brah.BL.Dtos.Responses.Resume;
using Brah.Data.Enums;

namespace Brah.BL.Abstractions;

public interface IDisplayResumesService
{
    public Task<List<ResumeShortResponseDto>> GetRange(
        string? profession = null,
        int? leftSalaryBorder = null,
        int? rightSalaryBorder = null,
        int[]? tags = null,
        Grade? grade = null);
    
    public Task<ResumeFullResponseDto> GetByUserName(string userName);
}