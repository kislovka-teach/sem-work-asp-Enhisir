using System.Security.Claims;
using Brah.BL.Dtos.Requests;
namespace Brah.BL.Abstractions;

public interface IAuthService
{
    public Task Register(RegisterRequestDto dto);
    public Task<ClaimsIdentity> Login(LoginRequestDto dto);
}