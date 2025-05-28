using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Dto
{
    public class TokenPair
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public List<string> Permissions { get; set; }

    }
}