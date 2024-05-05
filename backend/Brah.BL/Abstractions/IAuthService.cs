using Brah.BL.Dtos.Requests;
using Brah.BL.Dtos.Responses.Auth;

namespace Brah.BL.Abstractions;

public interface IAuthService
{
    public Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto);
    public Task<AuthResponseDto?> LoginAsync(LoginRequestDto dto);
    public AuthResponseDto? Refresh(string refreshToken);
}