using NetBlog.Domain.Common;

namespace NetBlog.Application.Common.Interfaces.Generators;

public interface IJwtTokenGenerator
{
    string GenerateToken(IUser user);
}