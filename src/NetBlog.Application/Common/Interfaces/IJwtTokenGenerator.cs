using NetBlog.Domain.Entities;

namespace NetBlog.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(Person person);
}
