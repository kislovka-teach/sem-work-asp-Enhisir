using System.Security.Claims;
using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Dtos.Requests.Resume;
using Brah.BL.Exceptions;
using Brah.Data.Abstractions;
using Brah.Data.Models.MtM;
using Brah.Data.Models.Resumes;
using Brah.Data.Models.Tags;

namespace Brah.BL.Services;

public class ManageResumeService(
    IMapper mapper,
    IHasTransactions transactionManager,
    IRepository<ResumeTagToResume> tagRelationsRepository,
    IUserRepository userRepository,
    IRepository<Resume> resumeRepository,
    IRepository<WorkPlace> workplaceRepository
) : IManageResumeService
{
    public async Task RemoveWorkplaceAsync(ClaimsIdentity identity, int workplaceId)
    {
        var user = await userRepository
            .GetSingleOrDefault(
                u => u.UserName.Equals(identity.Name),
                includeResume: true);
        var neededWorkplace = user!.Resume?.WorkPlaces.SingleOrDefault(wp => wp.Id == workplaceId);
        if (neededWorkplace == null) throw new NotFoundException();

        await workplaceRepository.RemoveAsync(neededWorkplace);
    }

    public async Task CreateResumeAsync(
        ClaimsIdentity identity,
        CreateResumeRequestDto requestDto)
    {
        var user = await userRepository
            .GetSingleOrDefault(t => t.UserName == identity.Name, includeResume: true);

        if (user == null) throw new NotFoundException();
        if (user.Resume != null) throw new AlreadyExistsException();

        var resume = mapper.Map<Resume>(requestDto);
        resume.UserId = user.Id;
        await resumeRepository.AddAsync(resume);
    }

    public async Task UpdateResumeAsync(ClaimsIdentity identity, UpdateResumeRequestDto requestDto)
    {
        var user = await userRepository
            .GetSingleOrDefault(t => t.UserName == identity.Name, includeResume: true);

        if (user?.Resume == null) throw new NotFoundException();

        transactionManager.BeginTransaction();
        try
        {
            foreach (var tag in user.Resume.Tags)
            {
                await tagRelationsRepository.RemoveAsync(
                    new ResumeTagToResume
                    {
                        ResumeId = user.Resume.Id,
                        ResumeTagId = tag.Id,
                    });
            }

            var resume = mapper.Map(requestDto, user.Resume);
            resume.UserId = user.Id;
            resume.Tags.Clear();

            var newTags = mapper.Map<List<ResumeTag>>(requestDto.Tags);

            var countIds = new Dictionary<int, int>();
            foreach (var id in newTags.Select(t => t.Id))
            {
                countIds.TryAdd(id, 0);
                countIds[id]++;
            }

            if (countIds.Any(pair => pair.Value > 1)) throw new InvalidOperationException();

            await tagRelationsRepository.AddRangeAsync(
                newTags.Select(
                    tag => new ResumeTagToResume
                    {
                        ResumeId = user.Resume.Id,
                        ResumeTagId = tag.Id,
                    }));
            await resumeRepository.UpdateAsync(resume);
            transactionManager.CommitTransaction();
        }
        catch
        {
            transactionManager.RollbackTransaction();
            throw;
        }
    }

    public async Task AddWorkPlaceAsync(
        ClaimsIdentity identity,
        CreateWorkPlaceDto requestDto)
    {
        var user = await userRepository
            .GetSingleOrDefault(t => t.UserName == identity.Name, includeResume: true);
        if (user?.Resume is null) throw new NotFoundException();
        var workplace = mapper.Map<WorkPlace>(requestDto);
        workplace.ResumeId = user.Resume.Id;
        await workplaceRepository.AddAsync(workplace);
    }

    public async Task UpdateWorkPlaceAsync(
        ClaimsIdentity identity,
        UpdateWorkPlaceDto requestDto)
    {
        var user = await userRepository
            .GetSingleOrDefault(t => t.UserName == identity.Name, includeResume: true);
        if (user?.Resume is null) throw new NotFoundException();
        var workplace = mapper.Map<WorkPlace>(requestDto);
        workplace.ResumeId = user.Resume.Id;
        await workplaceRepository.UpdateAsync(workplace);
    }
}