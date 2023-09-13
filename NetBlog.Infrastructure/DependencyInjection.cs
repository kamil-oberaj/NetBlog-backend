using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetBlog.Core;

namespace NetBlog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        ArgumentException.ThrowIfNullOrEmpty(connectionString);

        services.AddDbContext<NetBlogDbContext>((sp, options) =>
        {
            options.UseNpgsql(connectionString, opt => opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        });


        return services;
    }
}
