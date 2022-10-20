using Microsoft.AspNetCore.Identity;
using NetBlog.Application.Common.Models;

namespace NetBlog.Infrastructure.Identity.Extensions;

public static class IdentityResultExtension
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(er => er.Description));
    }
}
