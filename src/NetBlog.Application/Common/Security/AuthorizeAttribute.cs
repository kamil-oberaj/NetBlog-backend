namespace NetBlog.Application.Common.Security;

/// <summary>
/// This attribute is used for controllers that need authorization
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class AuthorizeAttribute : Attribute
{
    /// <summary>
    /// Initialize a new instance of the <see cref="AuthorizeAttribute"/> class.
    /// </summary>
    public AuthorizeAttribute() { }

    /// <summary>
    /// Gets or sets list of roles that are allowed to access the resource
    /// </summary>
    public string Roles { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the policy that determines access to the resource
    /// </summary>
    public string Policy { get; set; } = string.Empty;
}

