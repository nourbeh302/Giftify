using Domain.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Common.Authentication;

public class JwtProvider(IConfiguration configuration) : IJwtProvider
{
    private readonly IConfiguration _configuration = configuration;

    public string Generate(User user)
    {
        Claim[] claims = [
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), 
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("role", "User"),
            ];

        string secretKey = _configuration["Jwt:SecretKey"] ?? 
            throw new Exception();

        SigningCredentials signingCredentials = new(
            key: new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey)),
            algorithm: SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            notBefore: null,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: signingCredentials);

        string tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return tokenValue;
    }
}
