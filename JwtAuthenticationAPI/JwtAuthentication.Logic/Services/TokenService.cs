using JwtAuthentication.Logic.Common.Helpers;
using JwtAuthentication.Logic.Common.Models;
using JwtAuthentication.Logic.Common.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JwtAuthentication.Logic.Services
{
    public class TokenService : ITokenService
    {
        private readonly AuthOptions _authOptions;

        public TokenService(IOptions<AuthOptions> options)
        {
            _authOptions = options.Value;
        }

        public string GenerateToken(UserBLL user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString())
            };

            foreach (var role in user.UserRoles)
            {
                authClaims.Add(new Claim("role", role.Role.Name));
            }

            var token = new JwtSecurityToken(
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                expires: DateTime.Now.AddSeconds(_authOptions.TokenLifeTime),
                claims: authClaims,
                signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(),SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}