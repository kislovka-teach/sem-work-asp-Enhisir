using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Dtos.Responses.Resume;
using Brah.BL.Exceptions;
using Brah.Data.Abstractions;
using Brah.Data.Enums;
using Brah.Data.Models.Resumes;
using Microsoft.EntityFrameworkCore;

namespace Brah.BL.Services;

public class DisplayResumesService(
    IMapper mapper,
    IRepository<Resume> resumeRepository) : IDisplayResumesService
{
    public async Task<List<ResumeShortResponseDto>> GetRange(
        string? profession = null,
        int? leftSalaryBorder = null,
        int? rightSalaryBorder = null,
        int[]? tags = null,
        Grade? grade = null)
    {
        var query = await resumeRepository
            .GetRange()
            .Where(x => x.LookingForWork)
            .Where(x => profession == null
                        || EF.Functions.TrigramsAreSimilar(x.Profession, profession))
            .Where(x => leftSalaryBorder == null
                        || x.RightSalaryBorder >= leftSalaryBorder)
            .Where(x => rightSalaryBorder == null
                        || x.LeftSalaryBorder <= rightSalaryBorder)
            .Where(x => tags == null
                        || tags.Length == 0
                        || tags.Intersect(x.Tags.Select(t => t.Id)).Count() == tags.Length)
            .Where(x => grade == null || x.Grade == grade)
            .ToListAsync();

        return mapper.Map<List<ResumeShortResponseDto>>(query);
    }

    public async Task<ResumeFullResponseDto> GetByUserName(string userName)
    {
        var resume = await resumeRepository
            .GetSingleOrDefault(t => t.User.UserName == userName);

        if (resume is null) throw new NotFoundException();

        return mapper.Map<ResumeFullResponseDto>(resume);
    }
}