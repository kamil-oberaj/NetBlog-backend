using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace NetBlog.Infrastructure.Persistence.Initializers;

public class ApplicationIdentityDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly ApplicationIdentityDbContext _identityDbContext;

    public ApplicationIdentityDbContextInitializer(
        ILogger<ApplicationDbContextInitializer> logger,
        ApplicationIdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
        _logger = logger;
    }

    public async Task InitializeAsync()
    {
        try
        {
            if (_identityDbContext.Database.IsNpgsql())
                _identityDbContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the ApplicationIdentityDbContext context");
            throw;
        }
    }
}