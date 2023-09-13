using NetBlog.Core.Models.Base;

namespace NetBlog.Core.Models;

public sealed class PostEditor : Entity<int>
{
    public Guid EditorId { get; set; }
    public Guid PostId { get; set; }

    #region EntityRelations

    public User Editor { get; set; } = null!;
    public Post Post { get; set; } = null!;

    #endregion
}
