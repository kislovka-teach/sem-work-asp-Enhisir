using System.Security.Claims;
using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Dtos.Requests.Profile;
using Brah.Data.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Brah.BL.Services;

public class EditProfileService(
    IMapper mapper,
    IUserRepository userRepository,
    IPasswordHasherService passwordHasherService,
    IMinioService minioService
) : IEditProfileService
{
    public async Task EditProfile(ClaimsIdentity identity, EditProfileRequestDto dto)
    {
        var user = (await userRepository
            .GetSingleOrDefault(u => u.UserName.Equals(identity.Name)))!;

        var newUser = mapper.Map(dto, user);
        await userRepository.UpdateAsync(newUser);
    }

    public async Task ChangePassword(ClaimsIdentity identity, ChangePasswordRequestDto dto)
    {
        var user = (await userRepository
            .GetSingleOrDefault(u => u.UserName.Equals(identity.Name)))!;

        if (!passwordHasherService.Validate(user.PasswordHashed, dto.OldPassword))
            throw new InvalidPasswordException();

        user.PasswordHashed = passwordHasherService.Hash(dto.NewPassword);
        await userRepository.UpdateAsync(user);
    }

    public async Task UpdateImage(ClaimsIdentity identity, IFormFile image)
    {
        var user = (await userRepository
            .GetSingleOrDefault(u => u.UserName.Equals(identity.Name)))!;

        if (user.AvatarLink != null)
            await minioService.DeleteImage(user.AvatarLink);
        var imageId = await minioService.SaveImage(image);
        user.AvatarLink = imageId;
        await userRepository.UpdateAsync(user);
    }
}