using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetBlog.Domain.Models;
using NetBlog.Infrastructure.Configuration;

namespace NetBlog.Infrastructure.Providers;

internal sealed class JwtProvider : IJwtProvider
{
    private readonly JwtConfiguration _jwtConfiguration;

    public JwtProvider(IOptions<JwtConfiguration> jwtConfiguration)
    {
        _jwtConfiguration = jwtConfiguration.Value;
    }

    public string Generate(ref User user, ref HashSet<Role> userRoles)
    {
        var claims = new Span<Claim>();
        claims.Fill(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
        claims.Fill(new Claim(JwtRegisteredClaimNames.Email, user.Email!));
        claims.Fill(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        foreach (var userRole in userRoles)
        {
            claims.Fill(new Claim(ClaimTypes.Role, userRole.Name!));
        }


        var token = new JwtSecurityToken(
            issuer: _jwtConfiguration.Issuer,
            audience: _jwtConfiguration.Audience,
            claims: claims.ToImmutableArray(),
            notBefore: null,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: new SigningCredentials
            (
                new SymmetricSecurityKey(Encoding
                    .UTF8.GetBytes(_jwtConfiguration.Secret)),
                SecurityAlgorithms.HmacSha256
            )
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}