using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoneyTransferAPI.Infrastructure.Authentication
{
    public class JWTAuthenticationManager
    {
        private readonly IConfiguration _configuration;
        private readonly byte[] _key;
        private readonly IConfigurationSection _jwtSection;

        public JWTAuthenticationManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSection = _configuration.GetSection("JWT");
            _key = Encoding.ASCII.GetBytes(_jwtSection["Secret"]);
        }

        public string Authenticate(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_jwtSection["AccessTokenExpirationMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

