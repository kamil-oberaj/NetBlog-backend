using System.Net;
using NetBlog.Domain.Constants;

namespace NetBlog.Application.Common.Exceptions;
public class NetBlogValidationException
    : Exception,
    IBaseValidationException
{
    public NetBlogValidationException()
    {
        Errors = default!;
    }

    public NetBlogValidationException(
        IDictionary<string, string[]> errors)
    {
        Errors = errors;
    }

    public NetBlogValidationException(
        string? message
    ) : base(message)
    {
        Errors = new Dictionary<string, string[]>();
    }

    public NetBlogValidationException(
        string? message,
        Exception? innerException)
        : base(message, innerException)
    {
        Errors = new Dictionary<string, string[]>();
    }

    public IDictionary<string, string[]> Errors { get; }
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string Title { get; } = ErrorMessages.Exception.ValidationException;
}
