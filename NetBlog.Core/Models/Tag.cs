using NetBlog.Core.Models.Base;

namespace NetBlog.Core.Models;

public sealed class Tag : Entity<int>
{
    public required string FullName { get; set; } = null!;
    public string? ShortName { get; set; }

    #region EntityRelations

    public IQueryable<PostTag> PostTags { get; set; } = null!;

    #endregion
}
