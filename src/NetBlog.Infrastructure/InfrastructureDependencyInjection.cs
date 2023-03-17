using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetBlog.Infrastructure.Configuration;
using NetBlog.Infrastructure.Initializers;

namespace NetBlog.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static void RegisterInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddDbContext(ref configuration);
        services.AddScoped<DbContextInitializer>();
    }

    private static void AddDbContext(this IServiceCollection services,
        ref IConfiguration configuration)
    {

        var dbConnection = new DatabaseConfiguration();
        configuration.Bind(DatabaseConfiguration.ConfigSectionName, dbConnection);

        ArgumentNullException.ThrowIfNull(dbConnection);

        services.AddDbContext<NetBlogDbContext>(
            options =>
            {
                options.UseNpgsql(dbConnection.GetConnectionString(),
                    npgOptions => npgOptions
                        .MigrationsAssembly(typeof(NetBlogDbContext).Assembly.FullName));
                options.UseSnakeCaseNamingConvention();
            });
    }
}