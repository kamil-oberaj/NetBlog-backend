namespace NetBlog.Infrastructure.Identity;

public class RefreshToken
{
    public long Id { get; set; }
    public string Token { get; set; } = string.Empty;
    public string JwtId { get; set; } = string.Empty;
    public DateTime CreationTime { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool Used { get; set; }
    public bool Invalidated { get; set; }

    public Guid UserId { get; set; }
    public virtual ApplicationUser User { get; set; } = new();
}
