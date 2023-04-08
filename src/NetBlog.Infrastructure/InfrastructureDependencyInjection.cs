using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

        var jwtSettings = new JwtConfiguration();
        configuration.Bind(JwtConfiguration.ConfigSectionName, jwtSettings);

        ArgumentNullException.ThrowIfNull(jwtSettings);
        services.AddSingleton(jwtSettings);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                ValidAlgorithms = new HashSet<string> { SecurityAlgorithms.HmacSha256 },
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            };
        });
    }
}