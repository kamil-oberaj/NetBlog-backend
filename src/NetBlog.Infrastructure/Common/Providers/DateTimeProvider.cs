using NetBlog.Application.Common.Interfaces;

namespace NetBlog.Infrastructure.Common.Providers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.Now;
}