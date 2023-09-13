using Microsoft.AspNetCore.Identity;

namespace NetBlog.Core.Models;

public sealed class User : IdentityUser<Guid>
{

    #region EntityRelations

    public IQueryable<Post> OwnedPosts { get; set; } = null!;
    public IQueryable<PostEditor> EditedPosts { get; set; } = null!;
    public IQueryable<UserRole> UserRoles { get; set; } = null!;

    #endregion
}
