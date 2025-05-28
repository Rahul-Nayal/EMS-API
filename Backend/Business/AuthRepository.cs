using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business
{
    public class AuthRepository : IAuth
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IJWToken jWToken;
        private readonly EMSDbContext eMSDbContext;
        public AuthRepository(UserManager<IdentityUser> userManager, EMSDbContext eMSDbContext, IJWToken jWToken)
        {
            this.userManager = userManager;
            this.eMSDbContext = eMSDbContext;
            this.jWToken = jWToken;
        }
        public async Task<RegisterRequestDto> Register(RegisterRequestDto registerRequestDto)
        {
            var exisitingUser = await userManager.Users.FirstOrDefaultAsync(usr => usr.UserName == registerRequestDto.UserName);
            if (exisitingUser != null)
            {
                return null;
            }

            var user = new IdentityUser
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.UserName
            };

            var identityResult = await userManager.CreateAsync(user, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(user, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return registerRequestDto;
                    }
                }
            }
            return null;
        }

        public async Task<TokenPair> RefreshAsync(RefreshRequestDto token)
        {
            var refreshTokenModel = await eMSDbContext.RefreshTokens.FirstOrDefaultAsync(tk => tk.Token == token.Token);
            if (refreshTokenModel == null || refreshTokenModel.Expire <= DateTime.UtcNow)
            {
                throw new Exception("Invalid refreshToken ");
            }

            var user = await userManager.Users.FirstOrDefaultAsync(usr => usr.Id == refreshTokenModel.UserId.ToString());
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var roles = (await userManager.GetRolesAsync(user)).ToList();

            var newAccessToken = jWToken.createJWToken(user, roles);
            var permission = jWToken.GeneratePermission(roles);
            var newRefreshToken = jWToken.GenerateRefreshToken();

            refreshTokenModel.Token = newRefreshToken;
            refreshTokenModel.Expire = DateTime.Now.AddDays(7);

            await eMSDbContext.SaveChangesAsync();
            return new TokenPair
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                Permissions = permission
            };
        }
        

        

        // public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        // {
        //     var exisitingUser = await userManager.Users.FirstOrDefaultAsync(usr => usr.UserName == loginRequestDto.UserName);
        //     if (exisitingUser != null)
        //     {
        //         var checkPassword = await userManager.CheckPasswordAsync(exisitingUser, loginRequestDto.Password);
        //         if (checkPassword)
        //         {
        //             var roles = await userManager.GetRolesAsync(exisitingUser);
        //             if (roles != null)
        //             {
        //                 var jwtToken = jWToken.createJWToken(exisitingUser, roles.ToList());
        //                 var response = new LoginResponseDto
        //                 {
        //                     JWToken = jwtToken
        //                 };
        //                 return response;
        //             }
        //         }
        //     }
        //     return null;
        // }


    }
}