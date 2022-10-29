namespace NetBlog.Domain.Common;

/// <summary>
/// Provides basic security information
/// in case something fails and we want to
/// check which entity is connected to
/// specific security incident
/// </summary>
public abstract class AuditableEntity : BaseEntity
{
    public DateTime Created { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}