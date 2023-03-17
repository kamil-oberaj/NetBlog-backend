using Autofac;

namespace NetBlog.Infrastructure.Modules;

public static class InfrastructureModulesRegistrationExtensions
{
    public static void RegisterInfrastructureModules(this ContainerBuilder containerBuilder)
    {
        try
        {
            containerBuilder.RegisterModule(new ApplicationServiceModule());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Infrastructure init failed {ex.Message}");
            throw;
        }
    }
}