using Microsoft.EntityFrameworkCore;
using NetBlog.Core.Models;

namespace NetBlog.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();

    #region DbSets

    public DbSet<User> Users { get; }
    public DbSet<Role> Roles  { get; }
    public DbSet<UserRole> UserRoles { get; }
    public DbSet<Post> Posts { get; }
    public DbSet<Tag> Tags { get; }
    public DbSet<PostTag> PostTags { get; }
    public DbSet<PostEditor> PostEditors { get; }

    #endregion
}
