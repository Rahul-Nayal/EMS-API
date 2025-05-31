using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;

namespace Backend.Business
{
    public class JWTokenRepository : IJWToken
    {
        private readonly IConfiguration configuration;
        // private readonly IConnectionMultiplexer redis;
        private readonly EMSDbContext eMSDbContext;
        public JWTokenRepository(IConfiguration configuration, EMSDbContext eMSDbContext)
        {
            this.configuration = configuration;
            // this.redis = redis;
            this.eMSDbContext = eMSDbContext;
        }

        public string createJWToken(IdentityUser user, List<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim("user_id", user.Id));
            // claims.Add(new Claim(ClaimTypes.Name,user))
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var permissions = GeneratePermission(roles);
            foreach (var permission in permissions)
            {
                claims.Add(new Claim("Permission", permission));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    public TokenPair GenerateTokenPair(IdentityUser user, List<string> roles)
        {
            var existingRefreshToken =   eMSDbContext.RefreshTokens.FirstOrDefault(usr=> usr.UserId == user.Id);
            var refreshToken = GenerateRefreshToken();
            var accessToken = createJWToken(user, roles);
            var permission = GeneratePermission(roles);
            if (existingRefreshToken != null)
            {
                existingRefreshToken.Token = refreshToken;
                existingRefreshToken.Expire = DateTime.Now.AddDays(7);

                eMSDbContext.RefreshTokens.Update(existingRefreshToken);
                eMSDbContext.SaveChangesAsync();
                return new TokenPair
                {
                    AccessToken = accessToken,
                    RefreshToken = existingRefreshToken.Token,
                    Permissions = permission
                };
            }
            else
            {

                var refreshTokenModel = new RefreshToken
                {
                    UserId = user.Id,
                    Token = refreshToken,
                    Expire = DateTime.Now.AddDays(7)

                };
                eMSDbContext.RefreshTokens.Add(refreshTokenModel);
            }
            // var refreshToken = GenerateRefreshToken();
            // StoreRefreshTokenInRedis(user.Id, refreshToken);
            eMSDbContext.SaveChanges();

            return new TokenPair
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Permissions = permission
            };
        }
        // public TokenPair GenerateTokenPair(IdentityUser user, List<string> roles)
        // {

        //     var accessToken = createJWToken(user, roles);
        //     var refreshToken = GenerateRefreshToken();
        //     var permission = GeneratePermission(roles);

        //     // StoreRefreshTokenInRedis(user.Id, refreshToken);

        //     var refreshTokenModel = new RefreshToken
        //     {
        //         UserId = user.Id,
        //         Token = refreshToken,
        //         Expire = DateTime.Now.AddDays(7)

        //     };

        //     eMSDbContext.RefreshTokens.Add(refreshTokenModel);
        //     eMSDbContext.SaveChanges();

        //     return new TokenPair
        //     {
        //         AccessToken = accessToken,
        //         RefreshToken = refreshToken,
        //         Permissions = permission
        //     };
        // }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var reg = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                reg.GetBytes(randomNumber);
            }
            return Convert.ToBase64String(randomNumber);
        }

        public List<string> GeneratePermission(List<string> roles) {
            var allPermission = new List<string>();
            foreach (var role in roles)
            {
                var roleId = eMSDbContext.Roles
                            .Where(rl => rl.Name == role)
                            .Select(rl => rl.Id)
                            .FirstOrDefault();

                if (!string.IsNullOrEmpty(roleId))
                {
                    var permissions = eMSDbContext.RoleClaims
                                        .Where(rc => rc.RoleId == roleId && rc.ClaimType == "Permission")
                                        .Select(rc => rc.ClaimValue)
                                        .ToList();
                    allPermission.AddRange(permissions);
                }
            }
            return allPermission;
        }


        // private void StoreRefreshTokenInRedis(string userId, string refreshToken)
        // {
        //     var db = redis.GetDatabase();
        //     db.StringSet($"refresh_token:{userId}", refreshToken, TimeSpan.FromDays(7));
        // }

        // public string ValidateRefreshToken(string userId, string refreshToken)
        // {
        //     var db = redis.GetDatabase();
        //     var storedRefreshToken = db.StringGet($"refresh_token:{userId}");

        //     if (storedRefreshToken.IsNullOrEmpty)
        //     {
        //         return null;
        //     }
        //     if (storedRefreshToken != refreshToken)
        //     {
        //         return null;
        //     }

        //     return storedRefreshToken;
        // }

    }
}