using NetBlog.Application.Common.Interfaces;

namespace NetBlog.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}