using System.Security.Claims;
using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Dtos.Requests.Resume;
using Brah.BL.Exceptions;
using Brah.Data.Abstractions;
using Brah.Data.Models.Resumes;
using Brah.Data.Models.Tags;

namespace Brah.BL.Services;

public class ResumeService(
    IMapper mapper,
    IHasTransactions transactionManager,
    IUserRepository userRepository,
    IRepository<Resume> resumeRepository,
    IRepository<WorkPlace> workplaceRepository
) : IResumeService
{
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
        resume.Tags = [];
        resume.WorkPlaces = [];
        var tags = mapper.Map<List<ResumeTag>>(requestDto.Tags);
        var workplaces = mapper.Map<List<WorkPlace>>(requestDto.WorkPlaces);

        try
        {
            transactionManager.BeginTransaction();
            var realResume = await resumeRepository.AddAsync(resume);

            foreach (var wp in workplaces)
            {
                wp.ResumeId = realResume.Id;
                var realWorkPlace = await workplaceRepository.AddAsync(wp);
                realResume.WorkPlaces.Add(realWorkPlace);
            }
            realResume.Tags.AddRange(tags);
            await resumeRepository.UpdateAsync(realResume);
            transactionManager.CommitTransaction();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}