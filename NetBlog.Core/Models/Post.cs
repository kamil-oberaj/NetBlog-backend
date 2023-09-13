using NetBlog.Core.Models.Base;

namespace NetBlog.Core.Models;

public sealed class Post : Entity<Guid>, IAuditableEntity, ILikeableEntity
{
    public required string Name { get; set; }
    public required string Content { get; set; }
    public DateOnly CreatedAt { get; set; }
    public DateOnly? UpdatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public int UpVotes { get; set; }
    public int DownVotes { get; set; }

    #region EntityRelations

    public User PostOwner { get; set; } = null!;
    public IQueryable<PostEditor> PostEditors { get; set; } = null!;
    public IQueryable<PostTag> PostTags { get; set; } = null!;

    #endregion
}
