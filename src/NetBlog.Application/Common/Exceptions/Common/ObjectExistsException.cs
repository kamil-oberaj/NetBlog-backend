namespace NetBlog.Application.Common.Exceptions.Common;

public class ObjectExistsException : BaseExistsException
{
    public ObjectExistsException(string? exceptionOccurrence) : base(exceptionOccurrence)
    {
    }
}