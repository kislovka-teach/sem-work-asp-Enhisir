using System.Security.Claims;
using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Dtos.Meta;
using Brah.BL.Dtos.Requests;
using Brah.BL.Dtos.Requests.Auth;
using Brah.BL.Dtos.Responses.Auth;
using Brah.BL.Exceptions;
using Brah.Data.Abstractions;
using Brah.Data.Enums;
using Brah.Data.Models;
using Microsoft.IdentityModel.Tokens;

namespace Brah.BL.Services;

public class AuthService(
    IMapper mapper,
    IUserRepository userRepository,
    IPasswordHasherService passwordHasherService,
    IJwtService jwtService)
    : IAuthService
{
    public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
    {
        if (await userRepository
                .GetSingleOrDefault(
                    u => u.UserName == dto.UserName) is not null)
            throw new AlreadyExistsException();

        var user = mapper.Map<User>(dto);
        user.PasswordHashed = passwordHasherService.Hash(dto.Password);
        await userRepository.AddAsync(user);

        return CreateAuthResponse(user);
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginRequestDto dto)
    {
        var user = await userRepository
            .GetSingleOrDefault(
                u => u.UserName == dto.UserName);

        if (user is null
                      || !passwordHasherService.Validate(user.PasswordHashed, dto.Password))
            return null;

        return CreateAuthResponse(user);
    }

    public AuthResponseDto? Refresh(string refreshToken)
    {
        try
        {
            var identity = jwtService.ValidateToken(refreshToken);
            return CreateAuthResponse(identity);
        }
        catch (SecurityTokenException)
        {
            return null;
        }
    }

    private AuthResponseDto CreateAuthResponse(User user)
    {
        var accessTokenExpires = TimeSpan.FromDays(1);
        var refreshTokenExpries = TimeSpan.FromDays(30);

        var identity = GetUserIdentity(user);
        var accessToken = jwtService.GenerateToken(identity, accessTokenExpires);
        var refreshToken = jwtService.GenerateToken(identity, refreshTokenExpries);
        return new AuthResponseDto
        {
            User = mapper.Map<UserThumbnailDto>(user),
            AccessToken = accessToken,
            AccessTokenExpires = accessTokenExpires.TotalMilliseconds,
            RefreshToken = refreshToken
        };
    }

    private AuthResponseDto CreateAuthResponse(ClaimsIdentity identity)
    {
        var accessTokenExpires = TimeSpan.FromDays(1);
        var refreshTokenExpries = TimeSpan.FromDays(30);
        var accessToken = jwtService.GenerateToken(identity, accessTokenExpires);
        var refreshToken = jwtService.GenerateToken(identity, refreshTokenExpries);

        var userThumbnail = new UserThumbnailDto()
        {
            UserName = identity.Name!,
            Role = Enum.Parse<Role>(identity.FindFirst(identity.RoleClaimType)!.Value)
        };

        return new AuthResponseDto
        {
            User = userThumbnail,
            AccessToken = accessToken,
            AccessTokenExpires = accessTokenExpires.TotalMilliseconds,
            RefreshToken = refreshToken
        };
    }

    private ClaimsIdentity GetUserIdentity(User user)
    {
        var claims = new Claim[]
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Role, user.Role.ToString())
        };

        return new ClaimsIdentity(claims);
    }
}