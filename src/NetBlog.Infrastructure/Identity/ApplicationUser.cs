using Microsoft.AspNetCore.Identity;
using NetBlog.Domain.Common;
namespace NetBlog.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>, IUser { }