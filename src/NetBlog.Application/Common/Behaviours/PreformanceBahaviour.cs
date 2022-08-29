using System;
using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;
using NetBlog.Application.Common.Interfaces;

namespace NetBlog.Application.Common.Behaviours;

public class PreformanceBahaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;

    public PreformanceBahaviour(ILogger<TRequest> logger,
                               ICurrentUserService currentUserService,
                               IIdentityService identityService)
    {
        _timer = new Stopwatch();

        _logger = logger;
        _currentUserService = currentUserService;
        _identityService = identityService;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMS = _timer.ElapsedMilliseconds;

        if (elapsedMS > 500)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId ?? string.Empty;
            var userName = string.Empty;

            if (!string.IsNullOrEmpty(userId))
                userName = await _identityService.GetUserNameAsync(userId);

            _logger.LogWarning($"NetBlog request {@requestName} running too long ({elapsedMS}.\n" +
                $"Request made by {@userId} {@userName} {@request}");
        }

        return response;
    }
}

