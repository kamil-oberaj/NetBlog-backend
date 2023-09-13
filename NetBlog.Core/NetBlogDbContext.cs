using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NetBlog.Core.Models;

namespace NetBlog.Core;

public sealed class NetBlogDbContext : IdentityDbContext<User, Role, Guid>
{
    private IDbContextTransaction? _transaction;
    private bool HasOpenTransaction => _transaction != null;

    public async Task BeginTransactionAsync()
    {
        if (HasOpenTransaction)
            return;

        _transaction = await Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction is null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }

        await _transaction.CommitAsync();
        _transaction = null;
    }

    #region DbSets

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<PostTag> PostTags => Set<PostTag>();
    public DbSet<PostEditor> PostEditors => Set<PostEditor>();

    #endregion
}
