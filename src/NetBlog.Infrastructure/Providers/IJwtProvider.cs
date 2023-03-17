using NetBlog.Application.Shared;
using NetBlog.Domain.Models;

namespace NetBlog.Infrastructure.Providers;

internal interface IJwtProvider : IApplicationService
{
    string Generate(ref User user, ref HashSet<Role> userRoles);
}