using System.Security.Claims;
using Brah.BL.Dtos.Requests.Profile;
using Microsoft.AspNetCore.Http;

namespace Brah.BL.Abstractions;

public interface IEditProfileService
{
    public Task EditProfile(ClaimsIdentity identity, EditProfileRequestDto dto);
    public Task ChangePassword(ClaimsIdentity identity, ChangePasswordRequestDto dto);
    public Task UpdateImage(ClaimsIdentity identity, IFormFile image);
}