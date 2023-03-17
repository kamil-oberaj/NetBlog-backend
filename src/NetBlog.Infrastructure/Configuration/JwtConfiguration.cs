namespace NetBlog.Infrastructure.Configuration;

public class JwtConfiguration
{
    internal static string ConfigSectionName => "JWTConfiguration";

    public string Secret { get; init; } = string.Empty;
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
}