using NetBlog.Application.Common.Interfaces.Providers;

namespace NetBlog.Infrastructure.Common.Providers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.Now;
}