namespace NetBlog.Application.Common.Exceptions;

public interface IBaseValidationException : IBaseException
{
    public IDictionary<string, string[]> Errors { get; }
}