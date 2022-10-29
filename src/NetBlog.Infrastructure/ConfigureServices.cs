using System.Data.Common;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetBlog.Application.Common.Interfaces.Contexts;
using NetBlog.Application.Common.Interfaces.Generators;
using NetBlog.Application.Common.Interfaces.Providers;
using NetBlog.Application.Common.Interfaces.Ser;
using NetBlog.Infrastructure.Common.Authentication;
using NetBlog.Infrastructure.Persistence;
using NetBlog.Infrastructure.Persistence.Interceptors;
using NetBlog.Infrastructure.Common.Providers;
using NetBlog.Infrastructure.Common.Services;
using NetBlog.Infrastructure.Identity;
using NetBlog.Infrastructure.Identity.Settings;
using NetBlog.Infrastructure.Persistence.Initializers;

namespace NetBlog.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        #region DbContext

        DbConnectionStringBuilder connectionStringBuilder = new()
        {
            { "Server", configuration["SQ_DB_HOST"]! },
            { "Database", configuration["SQ_DB_NAME"]! },
            { "Port", configuration["SQ_DB_PORT"]! },
            { "Username", configuration["SQ_DB_USER"]! },
            { "Password", configuration["SQ_DB_PASSWORD"]! },
            { "Keepalive", configuration["SQ_DB_KEEPALIVE"]! }
        };

        services.AddApplicationDbContext(configuration, connectionStringBuilder);
        services.AddIdentityDbContext(configuration, connectionStringBuilder);
        services.AddAuth(configuration);

        #endregion

        #region Services

        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IDomainEventService, DomainEventService>();
        services.AddScoped<ApplicationDbContextInitializer>();
        services.AddScoped<ApplicationIdentityDbContextInitializer>();

        #endregion

        return services;
    }

    private static IServiceCollection AddApplicationDbContext(
        this IServiceCollection services,
        IConfiguration configuration,
        DbConnectionStringBuilder connectionStringBuilder)
    {
        if (!string.IsNullOrWhiteSpace(connectionStringBuilder.ConnectionString.FirstOrDefault().ToString()))
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")!,
                options => options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(connectionStringBuilder.ConnectionString,
                    options => options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        
        return services;
    }
    private static void AddIdentityDbContext(this IServiceCollection services,
        IConfiguration configuration,
        DbConnectionStringBuilder connectionStringBuilder)
    {
        if (!string.IsNullOrWhiteSpace(connectionStringBuilder.ConnectionString.FirstOrDefault().ToString()))
        {
            services.AddDbContext<ApplicationIdentityDbContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")!,
                    options => options.MigrationsAssembly(
                        typeof(ApplicationIdentityDbContext).Assembly.FullName)));
        }
        else
        {
            services.AddDbContext<ApplicationIdentityDbContext>(
                options => options.UseNpgsql(connectionStringBuilder.ConnectionString,
                    options => options.MigrationsAssembly(
                        typeof(ApplicationIdentityDbContext).Assembly.FullName)));
        }

        services.AddIdentityCore<ApplicationUser>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 1;
            
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 3;
            options.Lockout.AllowedForNewUsers = true;
            
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            options.User.RequireUniqueEmail = true;
        }).AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>();
    }

    private static void AddAuth(this IServiceCollection services,
        IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => 
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = JwtSettings.Issuer,
                    ValidAudience = JwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(JwtSettings.Secret))
                });
    }
}