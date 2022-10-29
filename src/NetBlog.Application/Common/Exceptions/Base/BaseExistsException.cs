using System.Net;
using NetBlog.Domain.Constants;

namespace NetBlog.Application.Common.Exceptions;

public abstract class BaseExistsException : Exception, IBaseException
{
    protected BaseExistsException(string? exceptionOccurrence)
    {
        Title = exceptionOccurrence + Title;
    }

    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string Title { get; set; } = ErrorMessages.ExceptionTitles.ExistsException;
}