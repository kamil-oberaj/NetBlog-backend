using Microsoft.EntityFrameworkCore;
using NetBlog.Domain.Entities;

namespace NetBlog.Application.Common.Interfaces.Contexts;

public interface IApplicationDbContext
{
    DbSet<Person> Persons { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}