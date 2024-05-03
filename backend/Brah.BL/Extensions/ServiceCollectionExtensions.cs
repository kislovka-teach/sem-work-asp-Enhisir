using Brah.BL.Abstractions;
using Brah.BL.Profiles;
using Brah.BL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Brah.BL.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IDisplayArticlesService, DisplayArticlesService>()
            .AddScoped<ISearchArticleTagsService, SearchArticleTagsService>()
            .AddScoped<IDisplayProfileService, DisplayProfileService>()
            .AddScoped<IDisplayResumesService, DisplayResumesService>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IPasswordHasherService, PasswordHasherService>();
    }

    public static IServiceCollection AddAutoMapperConfigured(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddAutoMapper(options => options.AddProfile<MappingProfile>());
    }
}