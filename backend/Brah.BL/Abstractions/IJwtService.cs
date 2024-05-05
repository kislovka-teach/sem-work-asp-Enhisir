using System.Security.Claims;

namespace Brah.BL.Abstractions;

public interface IJwtService
{
    public string GenerateToken(ClaimsIdentity userIdentity, TimeSpan expires);
    public ClaimsIdentity ValidateToken(string token);
}