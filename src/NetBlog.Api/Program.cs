using NetBlog.Api;
using NetBlog.Infrastructure;
using NetBlog.Infrastructure.Initializers;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .RegisterApiServices()
    .RegisterInfrastructureServices(builder.Configuration);


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await using (var scope = app.Services.CreateAsyncScope())
{
    var dbContextInitializer = scope.ServiceProvider.GetRequiredService<DbContextInitializer>();
    await dbContextInitializer.InitialiseAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();