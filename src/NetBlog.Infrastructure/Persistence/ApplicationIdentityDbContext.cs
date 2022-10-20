using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetBlog.Infrastructure.Common.Constants;
using NetBlog.Infrastructure.Identity;

namespace NetBlog.Infrastructure.Persistence;

public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationIdentityDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(DbSchemas.Identity);
        
        base.OnModelCreating(builder);
    }
}