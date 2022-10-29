using NetBlog.Domain.Common;

namespace NetBlog.Domain.Entities;

public class Person : AuditableEntity, IUser
{
    public Person()
    {
    }

    public Person(Guid userId, string firstName, string lastName, string email, string userName)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
    }
    
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
}