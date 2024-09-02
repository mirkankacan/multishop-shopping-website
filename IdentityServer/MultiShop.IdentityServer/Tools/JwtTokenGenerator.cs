using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiShop.IdentityServer.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(CheckAppUserViewModel checkAppUserViewModel)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrEmpty(checkAppUserViewModel.Role))
                claims.Add(new Claim(ClaimTypes.Role, checkAppUserViewModel.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, checkAppUserViewModel.Id));

            if (!string.IsNullOrEmpty(checkAppUserViewModel.Email))
                claims.Add(new Claim(ClaimTypes.Email, checkAppUserViewModel.Email)); claims.Add(new Claim(ClaimTypes.Name, checkAppUserViewModel.Email));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.ExpireMinute);
            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signingCredentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(handler.WriteToken(token), expireDate);
        }
    }
}