using System.Security.Claims;
using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Dtos.Requests;
using Brah.BL.Exceptions;
using Brah.Data.Abstractions;
using Brah.Data.Models;

namespace Brah.BL.Services;

public class AuthService(
    IMapper mapper,
    IUserRepository userRepository,
    IPasswordHasherService passwordHasherService)
    : IAuthService
{
    public async Task Register(RegisterRequestDto dto)
    {
        if (await userRepository
                .GetSingleOrDefault(
                    u => u.UserName == dto.UserName) is not null)
            throw new AlreadyExistsException();

        var user = mapper.Map<User>(dto);
        user.PasswordHashed = passwordHasherService.Hash(dto.Password);
        await userRepository.AddAsync(user);
    }

    public async Task<ClaimsIdentity> Login(LoginRequestDto dto)
    {
        var user = await userRepository
                .GetSingleOrDefault(
                    u => u.UserName == dto.UserName);

        if (user is null) throw new NotAuthorizedException();
        if (passwordHasherService.Validate(user.PasswordHashed, dto.Password))
            throw new NotAuthorizedException();

        var claims = new Claim[]
        {
            new (ClaimTypes.Name, user.UserName),
            new (ClaimTypes.Role, user.Role.ToString())
        };

        return new ClaimsIdentity(claims);
    }
}