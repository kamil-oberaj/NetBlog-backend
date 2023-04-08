namespace NetBlog.Infrastructure.Configuration;

public class DatabaseConfiguration
{
    internal static string ConfigSectionName { get; set; } = "Database";

    public string? ConnectionString { get; init; }
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public string GetConnectionString()
    {
        var connectionString = ConnectionString;

        if (connectionString?.EndsWith(';') == false)
        {
            connectionString += ';';
        }

        return $"{connectionString}User Id={User};Password={Password}";
    }
}