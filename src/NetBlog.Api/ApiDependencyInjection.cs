namespace NetBlog.Api;

internal static class ApiDependencyInjection
{
    internal static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();


        return services;
    }
}