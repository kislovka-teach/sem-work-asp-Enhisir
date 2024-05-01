using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Brah.Data.Extensions;

public static class DbContextExtension
{
    public static IServiceCollection AddDbContextConfigured(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetService<IConfiguration>()!;
        
        return services
                .AddDbContext<AppDbContext>(
                options => options.UseNpgsql(
                    configuration.GetConnectionString("BrahDatabase")));
    }
}