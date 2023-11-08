using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepoLayer.Service
{
    public class JwtToken
    {
        private readonly IConfiguration configuration;

        public JwtToken(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GenerateToken(string email, int userId, string role)
        {
            List<Claim> claimData = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, email),
                new Claim("UserId", userId.ToString()),
                new Claim("Role", role),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:SecretKey"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer : "",
                audience :"",
                claims : claimData,
                notBefore : DateTime.Now,
                expires : DateTime.Now.AddMinutes(30),
                signingCredentials : cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return 
        }
    }
}
