using System.Net;
using NetBlog.Domain.Constants;

namespace NetBlog.Application.Common.Exceptions;

public abstract class BaseException : Exception, IBaseException
{
    public virtual HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public virtual string Title { get; set; } = ErrorMessages.ExceptionTitles.ApplicationException;
}