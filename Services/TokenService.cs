using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AuthDemo.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Collections.Generic;

namespace AuthDemo.Services
{
    public static class TokenService
    {
        public static string GenerateToken(User user, Settings settings)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(settings.SecretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),                               
            };

            foreach(var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityDescriptor = new SecurityTokenDescriptor
            {
                Audience = settings.Audience,
                Expires = DateTime.UtcNow.AddHours(settings.ExpiresIn),
                Issuer = settings.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var securityToken = tokenHandler.CreateJwtSecurityToken(securityDescriptor);
            string tokenJwt = tokenHandler.WriteToken(securityToken);

            return tokenJwt;
        }
    }
}