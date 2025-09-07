
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OLMS.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


namespace Olms.Models
{
    public class AuthService : IAuthService
    {
        private readonly OlmsDbContext _context;
        private readonly JwtSettings _jwtSettings;

        public AuthService(OlmsDbContext context, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> Authenticate(string username, string password)
        {
            var user = _context.Creds.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefault();

            if (user == null) // Use hashed passwords in production
            {
                return null;
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
