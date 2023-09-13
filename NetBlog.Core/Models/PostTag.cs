using NetBlog.Core.Models.Base;

namespace NetBlog.Core.Models;

public sealed class PostTag : Entity<int>
{
    public Guid PostId { get; set; }
    public int TagId { get; set; }
    #region EntityRelations

    public Tag Tag { get; set; } = null!;
    public Post Post { get; set; } = null!;

    #endregion
}
