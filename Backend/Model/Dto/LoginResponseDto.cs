using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Dto
{
    public class LoginResponseDto
    {
        public string JWToken { get; set; }
        public string RefreshToken { get; set; }
        public List<string> Permissions { get; set; }
    }
}