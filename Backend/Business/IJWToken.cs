using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Backend.Model.Dto
{
    public interface IJWToken
    {
        string createJWToken(IdentityUser user, List<string> Roles);
        TokenPair GenerateTokenPair(IdentityUser user, List<string> Roles);
        string GenerateRefreshToken();
        List<string> GeneratePermission(List<string> Roles);
    }
}