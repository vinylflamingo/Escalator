using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Escalator.API.Interfaces;

namespace Escalator.API
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager 
    {

        private readonly string key;

        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }
        
        //checks user credentials, if valid creates a key based on role.
        public string Authenticate(string username, string password, DBContext context)
        {
            //first we collect the users.
            var users = context.Agents;

            //next we see if the user doesn't exist.
            if (!users.Any(u => u.Username == username && u.Password == password))
            {
                return null;
            }

            //now that we know a user does exist we collect that user and store in the variable.
            var user = context.Agents.First(u => u.Username == username);

            //this is a little setup for JWT authentication
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);

            // admin token
            if (user.Role == "admin")
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "admin")
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
                )
                }; 
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            //manager token
            else if (user.Role == "manager")
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "manager")
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
                )
                }; 
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            //user token
            else
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "user")
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
}