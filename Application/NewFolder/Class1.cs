using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Domain.Entity;
using Microsoft.IdentityModel.Tokens;

namespace Application.NewFolder
{
   public static class Class1
    {
        public static string GenerateToken(Domain.Entity.User identityUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("!@@!789456");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("ID", identityUser.id),
                    new Claim("Name", identityUser.name),
                    new Claim("Role", identityUser.name)
                }),

                Expires = DateTime.UtcNow.AddDays(10),
                //SigningCredentials = new
                //SigningCredentials(
                //    new SymmetricSecurityKey(key),
                //    SecurityAlgorithms.HmacSha256Signature),
             
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static JwtSecurityToken ReadJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
          var read=  tokenHandler.ReadJwtToken( token);
            return read;
                }
        public static bool CanReadToken(string token) {
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.CanReadToken(token);
        }
    }
}

