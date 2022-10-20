using NetBlog.Domain.Common;

namespace NetBlog.Application.Common.Models;

public class BaseUser : IUser
{
    public BaseUser() { }

    public BaseUser(Guid id, string userName, string email)
    {
        Id = id;
        UserName = userName;
        Email = email;
    }

    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
}