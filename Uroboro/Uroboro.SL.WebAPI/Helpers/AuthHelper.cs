using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Uroboro.Common.Models;

namespace Uroboro.SL.WebAPI.Helpers
{
    public static class AuthHelper
    {
        public static User Authenticate(JwtAuthRequest authData, IEnumerable<User> users)
        {
            User user = users.FirstOrDefault(i => i.Username == authData.Username && i.Password == authData.Password);
            return user;
        }

        public static string BuildToken(User user, string jwtKey, string jwtIsssuer)
        {
            var rnd = new Random();
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwtIsssuer,
                jwtIsssuer,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
