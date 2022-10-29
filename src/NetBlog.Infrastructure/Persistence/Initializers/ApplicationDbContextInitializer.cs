using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace NetBlog.Infrastructure.Persistence.Initializers;

public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly ApplicationDbContext _applicationDbContext;

    public ApplicationDbContextInitializer(
        ILogger<ApplicationDbContextInitializer> logger,
        ApplicationDbContext applicationDbContext)
    {
        _logger = logger;
        _applicationDbContext = applicationDbContext;
    }

    public async Task InitializeAsync()
    {
        try
        {
            if (_applicationDbContext.Database.IsNpgsql())
                await _applicationDbContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing ApplicationDbContext context.");
            throw;
        }
    }
}