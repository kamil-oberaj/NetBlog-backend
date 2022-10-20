using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetBlog.Application.Common.Interfaces;
using NetBlog.Infrastructure.Common.Constants;
using NetBlog.Infrastructure.Common.Extensions;
using NetBlog.Infrastructure.Persistence.Interceptors;

namespace NetBlog.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(DbSchemas.Business);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}