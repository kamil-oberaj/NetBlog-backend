using System.Net;
using NetBlog.Domain.Constants;

namespace NetBlog.Application.Common.Exceptions;
public class NetBlogValidationException : BaseValidationException
{
    public NetBlogValidationException(IDictionary<string, string[]> errors) : base(errors) { }
}
