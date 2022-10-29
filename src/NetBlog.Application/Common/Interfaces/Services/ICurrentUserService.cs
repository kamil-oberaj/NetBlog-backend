namespace NetBlog.Application.Common.Interfaces.Services;

public interface ICurrentUserService
{
    string? UserId { get; }
    string? Email { get; }
}