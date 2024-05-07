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
            .AddSingleton<JwtOptions>()
            .AddScoped<IJwtService, JwtService>()
            .AddScoped<IDisplayArticlesService, DisplayArticlesService>()
            .AddScoped<IDisplayProfileService, DisplayProfileService>()
            .AddScoped<IDisplayResumesService, DisplayResumesService>()
            .AddScoped<IManageArticleService, ManageArticleService>()
            .AddScoped<IManageResumeService, ManageResumeService>()
            .AddScoped<ICommentaryService, CommentaryService>()
            .AddScoped<ITagsService, TagsService>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IPasswordHasherService, PasswordHasherService>()
            .AddScoped<IEditProfileService, EditProfileService>()
            .AddScoped<IMinioService, MinioService>()
            .AddScoped<INotificationsService, NotificationsService>()
            .AddScoped<ISubscriptionService, SubscriptionService>();
    }

    public static IServiceCollection AddAutoMapperConfigured(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddAutoMapper(options => options.AddProfile<MappingProfile>());
    }
}