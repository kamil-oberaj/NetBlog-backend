using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetBlog.Domain.Models;

namespace NetBlog.Infrastructure;

public class NetBlogDbContext : IdentityDbContext<User, Role, Guid>
{

    public NetBlogDbContext(DbContextOptions options)
        : base(options)
    {
    }
}