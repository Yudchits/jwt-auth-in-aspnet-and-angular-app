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
            var securityKey = _authOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            foreach (var role in user.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            }

            var token = new JwtSecurityToken
            (
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddSeconds(_authOptions.TokenLifeTime),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}