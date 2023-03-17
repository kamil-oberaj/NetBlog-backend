using Autofac;
using NetBlog.Application.Shared;

namespace NetBlog.Infrastructure.Modules;

public class ApplicationServiceModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = typeof(IApplicationService).Assembly;
        builder.RegisterAssemblyTypes(assembly)
            .Where(x => x.IsAssignableTo<IApplicationService>())
            .AsImplementedInterfaces();
    }
}