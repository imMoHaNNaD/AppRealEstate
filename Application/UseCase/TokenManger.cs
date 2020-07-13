using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.UseCase
{
   public static class TokenManger
    {
		const string key = "asdv234234^&%&^%&^hjsdfb2%%%";
		public static string GenerateToken(string userId)
		{
			var mySecret = key;
			var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

			var myIssuer = "http://mysite.com";
			var myAudience = "http://myaudience.com";

			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
			new Claim(ClaimTypes.NameIdentifier, userId),
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				Issuer = myIssuer,
				Audience = myAudience,
				SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		public static bool ValidateCurrentToken(string token)
		{
			var mySecret = key;
			var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

			var myIssuer = "http://mysite.com";
			var myAudience = "http://myaudience.com";

			var tokenHandler = new JwtSecurityTokenHandler();
			try
			{
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = myIssuer,
					ValidAudience = myAudience,
					IssuerSigningKey = mySecurityKey
				}, out SecurityToken validatedToken);
			}
			catch
			{
				return false;
			}
			return true;
		}
	}
}
