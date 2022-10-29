using System.Net;

namespace NetBlog.Application.Common.Exceptions;

public interface IBaseException
{
    public HttpStatusCode StatusCode { get; }
    public string Title { get; set; }
}