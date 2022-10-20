using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetBlog.Application.Common.Interfaces;
using NetBlog.Infrastructure.Identity;
using NetBlog.Infrastructure.Persistence;
using NetBlog.Infrastructure.Persistence.Interceptors;
using NetBlog.Infrastructure.Common.Providers;

namespace NetBlog.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        #region DbContext

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        #endregion

        #region Services

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        #endregion

        return services;
    }
}