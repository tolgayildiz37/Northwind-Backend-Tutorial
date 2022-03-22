using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Abstract
{
    public interface ITokenHelper<TToken> where TToken : class, IToken, new()
    {
        TToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
