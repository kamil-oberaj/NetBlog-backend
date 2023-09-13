using Microsoft.AspNetCore.Identity;

namespace NetBlog.Core.Models;

public sealed class Role : IdentityRole<Guid>
{

    #region EntityRelations

    public IQueryable<UserRole> UserRoles { get; set; } = null!;

    #endregion
}
