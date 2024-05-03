using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Dtos.Meta;
using Brah.BL.Dtos.Responses.Article;
using Brah.BL.Dtos.Responses.Resume;
using Brah.Data.Abstractions;
using Brah.Data.Enums;
using Brah.Data.Models.Resumes;
using Microsoft.EntityFrameworkCore;

namespace Brah.BL.Services;

public class DisplayResumesService(
    IMapper mapper,
    IRepository<Resume> resumeRepository) : IDisplayResumesService
{
    public List<ResumeShortResponseDto> GetAll()
    {
        var query = resumeRepository.GetRange();
        return mapper.Map<List<ResumeShortResponseDto>>(query);
    }

    public async Task<List<ArticleShortResponseDto>> GetFiltered(
        string? profession = null,
        int? leftSalaryBorder = null,
        int? rightSalaryBorder = null,
        List<TagDto>? tags = null,
        List<Grade>? grades = null)
    {
        var query = await resumeRepository.GetRange()
            .Where(x => profession == null || EF.Functions.TrigramsAreSimilar(x.Profession, profession))
            .Where(x => leftSalaryBorder == null || x.LeftSalaryBorder >= leftSalaryBorder)
            .Where(x => rightSalaryBorder == null || x.RightSalaryBorder <= rightSalaryBorder)
            .Where(x => tags == null || tags.Count == 0 ||
                        tags.Select(t => t.Id).Order()
                            .SequenceEqual(x.Tags.Select(t => t.Id).Order()))
            .Where(x => grades == null || grades.Count == 0 || grades.Contains(x.Grade))
            .ToListAsync();

        return mapper.Map<List<ArticleShortResponseDto>>(query);
    }

    public async Task<ArticleFullResponseDto?> GetById(int id)
    {
        var resume = await resumeRepository
            .GetSingleOrDefault(t => t.Id == id);
        return mapper.Map<ArticleFullResponseDto>(resume);
    }
}