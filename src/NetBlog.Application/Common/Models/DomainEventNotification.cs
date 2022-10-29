using MediatR;
using NetBlog.Domain.Common;

namespace NetBlog.Application.Common.Models;

public class DomainEventNotification<TDomainEvent>
    : INotification where TDomainEvent : DomainEvent
{
    public DomainEventNotification(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }

    private TDomainEvent DomainEvent { get; }
}