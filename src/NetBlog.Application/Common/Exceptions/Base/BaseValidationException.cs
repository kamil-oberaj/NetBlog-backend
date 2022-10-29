using System.Net;
using NetBlog.Domain.Constants;

namespace NetBlog.Application.Common.Exceptions;

public abstract class BaseValidationException : Exception, IBaseValidationException
{
    protected BaseValidationException(IDictionary<string, string[]> errors)
    {
        Errors = errors;
    }

    public IDictionary<string, string[]> Errors { get; }
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string Title { get; set; } = ErrorMessages.ExceptionTitles.ValidationException;
}