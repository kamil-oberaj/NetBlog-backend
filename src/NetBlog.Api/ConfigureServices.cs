using Microsoft.AspNetCore.Mvc.Infrastructure;
using NetBlog.Api.Common.Errors;
using NetBlog.Api.Common.Services;
using NetBlog.Application.Common.Interfaces.Services;

namespace NetBlog.Api;

public static class ConfigureServices
{
    public static IServiceCollection AddNetBlogApiServices(this IServiceCollection services)
    {

        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddSingleton<ProblemDetailsFactory, NetBlogProblemDetailsFactory>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks();
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}