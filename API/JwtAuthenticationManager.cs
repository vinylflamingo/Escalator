using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Escalator.API
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager 
    {

        private readonly string key;

        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }
        
        public string Authenticate(string username, string password, DBContext context)
        {
            var users = context.Agents;
            if (!users.Any(u => u.Username == username && u.Password == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
            

        }
    }
}