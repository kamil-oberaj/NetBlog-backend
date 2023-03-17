using NetBlog.Infrastructure.Configuration;
using Xunit;

namespace NetBlog.Infrastructure.Tests.Configuration;

public sealed class DataBaseConfigurationTests
{
    private readonly DatabaseConfiguration _dbConfiguration = new()
    {
        ConnectionString = nameof(DatabaseConfiguration.ConnectionString),
        User = nameof(DatabaseConfiguration.User),
        Password = nameof(DatabaseConfiguration.Password)
    };

    [Fact]
    public void Should_return_proper_connection_string()
    {
        var actual = _dbConfiguration.GetConnectionString();
        var expected = $"{nameof(DatabaseConfiguration.ConnectionString)};User Id={nameof(DatabaseConfiguration.User)};" +
                       $"Password={nameof(DatabaseConfiguration.Password)}";

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Should_return_connection_string_containing_semicolon_in_expected_place()
    {
        var result = _dbConfiguration.GetConnectionString();

        Assert.Contains(";User", result);
    }
}