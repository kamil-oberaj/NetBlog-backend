using System.Reflection;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace NetBlog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}