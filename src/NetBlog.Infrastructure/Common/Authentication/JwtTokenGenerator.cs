using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetBlog.Application.Common.Interfaces;
using NetBlog.Domain.Entities;
using NetBlog.Infrastructure.Identity.Settings;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace NetBlog.Infrastructure.Common.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTime _dateTime;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTime dateTime, IOptions<JwtSettings> jwtSettings)
    {
        _dateTime = dateTime;
        _jwtSettings = jwtSettings.Value;
    }
    public string GenerateToken(Person person)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey
            (
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, person.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, person.UserName),
            new Claim(JwtRegisteredClaimNames.GivenName, person.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, person.LastName),
            new Claim(JwtRegisteredClaimNames.Email, person.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken
        (
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: _dateTime.Now.AddMinutes(_jwtSettings.ExpirtyMinutes),
            signingCredentials: signingCredentials
        );
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
