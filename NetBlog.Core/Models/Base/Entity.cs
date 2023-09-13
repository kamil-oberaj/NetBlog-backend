namespace NetBlog.Core.Models.Base;

public abstract class Entity<TKey>
{
    public required TKey Id { get; set; }
    public required bool Deleted { get; set; } = false;
}
