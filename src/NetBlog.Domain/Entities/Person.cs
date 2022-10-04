using NetBlog.Domain.Common;

namespace NetBlog.Domain.Entities;

public class Person : BaseAuditableEntity, IUser
{
    public Person() { }
    public Person(Guid userId, string firstName, string lastName, string email, string userName)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
    }

    public Guid UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}