namespace NetBlog.Domain.Common;

public interface IHasDomainEven
{
    public List<DomainEvent> DomainEvents { get; }
}

public abstract class DomainEvent
{
    protected  DomainEvent()
    {
        DateOccurred = DateTimeOffset.UtcNow;
    }

    public bool IsPublished { get; set; }
    private DateTimeOffset DateOccurred { get; } = DateTimeOffset.UtcNow;
}
