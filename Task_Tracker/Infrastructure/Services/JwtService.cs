using Application.Interfaces.IServices;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateTokenForUser(ApplicationUser applicationUser)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier,applicationUser.Id));
            claims.Add(new Claim(ClaimTypes.Email, applicationUser.Email));
            var key = _configuration["JwtSettings:Secret"];
            var symKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var algo = SecurityAlgorithms.HmacSha256Signature;
            var signInCred = new SigningCredentials(symKey,algo);
            var jwtToken = new JwtSecurityToken(_configuration["JwtSettings:Issuer"], _configuration["JwtSettings:Audience"], claims, DateTime.UtcNow, DateTime.UtcNow.AddDays(30),signInCred);
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
