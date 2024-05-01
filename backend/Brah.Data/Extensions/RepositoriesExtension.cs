using Brah.Data.Abstractions;
using Brah.Data.Models.Articles;
using Brah.Data.Models.Resumes;
using Brah.Data.Models.Tags;
using Brah.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Brah.Data.Extensions;

public static class RepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IRepository<Article>, ArticleRepository>()
            .AddScoped<IRepository<ArticleTag>, StandardRepository<ArticleTag>>()
            .AddScoped<IRepository<ResumeTag>, StandardRepository<ResumeTag>>()
            .AddScoped<IRepository<Topic>, StandardRepository<Topic>>()
            .AddScoped<IRepository<Commentary>, CommentaryRepository>()
            .AddScoped<IRepository<Resume>, ResumeRepository>()
            .AddScoped<IRepository<WorkPlace>, StandardRepository<WorkPlace>>();
    }
}