using Microsoft.AspNetCore.Identity;

namespace NetBlog.Core.Models;

public sealed class UserRole : IdentityUserRole<Guid>
{
    #region EntityRelations

    public User User { get; set; } = null!;
    public Role Role { get; set; } = null!;

    #endregion
}
