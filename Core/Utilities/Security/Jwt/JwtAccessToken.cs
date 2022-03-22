using Core.Utilities.Security.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class JwtAccessToken : IToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
