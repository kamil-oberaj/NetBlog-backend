namespace NetBlog.Infrastructure.Identity.Settings;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public int ExpirtyMinutes { get; init; }
    public string Secret { get; init; } = string.Empty;
    public string Issuer { get; init; } = string.Empty;
    public string Audience {  get; init; } = string.Empty;
}
