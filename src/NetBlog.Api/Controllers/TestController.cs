using Microsoft.AspNetCore.Mvc;
using NetBlog.Api.Contracts;

namespace NetBlog.Api.Controllers;

public class TestController : ApiControllerBase
{
    [HttpGet(ApiRoutes.Identity.SignIn)]
    public ActionResult<string> Get() => "this is a simple string";
}
