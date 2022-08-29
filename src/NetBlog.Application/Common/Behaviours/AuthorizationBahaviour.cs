using System;
using System.Reflection;
using MediatR;
using NetBlog.Application.Common.Interfaces;
using NetBlog.Application.Common.Exceptions;
using NetBlog.Application.Common.Security;
namespace NetBlog.Application.Common.Behaviours;

public class AuthorizationBahaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;

    public AuthorizationBahaviour(ICurrentUserService currentUserService,
                                  IIdentityService identityService)
    {
        _currentUserService = currentUserService;
        _identityService = identityService;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        if (_currentUserService.UserId == null)
            throw new UnauthorizedAccessException();

        // Role-based authorization
        var authorizeAttributeWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));
        if (authorizeAttributeWithRoles.Any())
        {
            var authorized = false;

            foreach (var roles in authorizeAttributeWithRoles.Select(a => a.Roles.Split(',')))
            {
                foreach (var role in roles)
                {
                    var isInRole = await _identityService.IsInRoleAsync(_currentUserService.UserId, role.Trim());
                    if (isInRole)
                    {
                        authorized = true;
                        break;
                    }
                }
            }
            if (!authorized)
                throw new ForbiddenAccessException();
        }

        // Policy-based authorization
        var authorizeAttributeWithPolices = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Policy));
        if (authorizeAttributeWithPolices.Any())
        {
            foreach (var policy in authorizeAttributeWithPolices.Select(a => a.Policy))
            {
                var authorized = await _identityService.AuthorizeAsync(_currentUserService.UserId, policy);
                if (!authorized)
                    throw new ForbiddenAccessException();
            }
        }

        return await next();
    }
}

