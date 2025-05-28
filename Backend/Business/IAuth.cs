using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;

namespace Backend.Business
{
    public interface IAuth
    {
        Task<RegisterRequestDto> Register(RegisterRequestDto registerRequestDto);
        Task<TokenPair> RefreshAsync(RefreshRequestDto token); 
        // Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}