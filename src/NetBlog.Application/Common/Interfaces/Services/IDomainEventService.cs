using NetBlog.Domain.Common;

namespace NetBlog.Application.Common.Interfaces.Ser
;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}