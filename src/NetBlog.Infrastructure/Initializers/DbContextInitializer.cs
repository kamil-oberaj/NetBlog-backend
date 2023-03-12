using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace NetBlog.Infrastructure.Initializers;

public sealed class DbContextInitializer
{
    private readonly ILogger<DbContextInitializer> _logger;
    private readonly NetBlogDbContext _context;

    public DbContextInitializer(
        ILogger<DbContextInitializer> logger,
        NetBlogDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            _logger.LogInformation("Migrating database");
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }
}