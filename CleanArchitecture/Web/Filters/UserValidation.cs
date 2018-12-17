using Application.Interfaces;
using Application.Specifications.UserSpecifications;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Filters
{
    public class UserValidation : JwtBearerEvents
    {
        public override Task TokenValidated(TokenValidatedContext context)
        {
            if (context.Principal.HasClaim(c => c.Type == "userId"))
            {
                var userIdClaim = context.Principal.Claims.First(c => c.Type == "userId");
                var data = context.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();

                var user = data.Users.GetSingleBySpec(new UserWithRolesSpecification(int.Parse(userIdClaim.Value)));

                if(user != null)
                {
                    var claims = user.UserRoles
                        .Select(r => Enum.GetName((r.Role.Value.GetType()), r.Role.Value))
                        .Select(r => new Claim(ClaimTypes.Role, r));

                    context.Principal.AddIdentity(new ClaimsIdentity(claims));
                }
            }

            return Task.CompletedTask;
        }
    }
}
