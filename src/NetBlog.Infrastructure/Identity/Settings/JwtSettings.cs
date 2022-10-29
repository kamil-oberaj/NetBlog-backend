namespace NetBlog.Infrastructure.Identity.Settings;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public int ExpiryMinutes { get; init; }
    public static string Secret => null!;
    public static string Issuer => null!;
    public static string Audience => null!;
}