using NetBlog.Api;
using NetBlog.Application;
using NetBlog.Infrastructure;
using NetBlog.Infrastructure.Persistence.Initializers;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services
        .AddApplicationServices()
        .AddInfrastructureServices(builder.Configuration)
        .AddNetBlogApiServices();
}

var app = builder.Build();
{
// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        var scope = app.Services.CreateScope();
        var identityInitializer = scope.ServiceProvider.GetRequiredService<ApplicationIdentityDbContextInitializer>();
        await identityInitializer.InitializeAsync();

        var businessInitializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
        await businessInitializer.InitializeAsync();
    }

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}