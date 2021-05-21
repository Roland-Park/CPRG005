using CPRG005.Final.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CPRG005.Final.BLL.Services
{
    public interface ITokenService
    {
        string CreateToken(Authorize authorization);
    }
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string CreateToken(Authorize authorization)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtKey")));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, authorization.UserName),
                    new Claim(ClaimTypes.Role, "a dude")
                };
            var tokeOptions = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("Issuer"),
                audience: configuration.GetValue<string>("Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(configuration.GetValue<string>("TimeoutInMinutes"))),
                signingCredentials: signinCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
    }
}
