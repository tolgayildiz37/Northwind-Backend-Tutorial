using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Concrete
{
    public class TokenOptions
    {
        //Hedef Kitle
        public string Audience { get; set; }
        //İmzalayan
        public string Issuer { get; set; }
        //Dakika Cinsi
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }

    }
}
