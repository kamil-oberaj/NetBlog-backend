namespace NetBlog.Infrastructure.Configuration;

public class DatabaseConfiguration
{
    internal const string ConfigSectionName = "Database";

    public string? ConnectionString { get; init; }
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public string GetConnectionString()
    {
        var connectionString = ConnectionString;

        if (connectionString != null && !connectionString.EndsWith(';'))
        {
            connectionString += ';';
        }

        return $"{connectionString}User Id={User};Password={Password}";
    }
}