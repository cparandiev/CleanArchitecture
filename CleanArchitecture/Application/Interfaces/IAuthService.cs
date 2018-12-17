using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        string CreateJWT(string secret, Claim[]  claims, string issuer, string audience, DateTime expires);
    }
}
