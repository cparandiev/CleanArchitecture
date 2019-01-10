using Application.Extensions;
using Application.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Web.Constants.Claim;

namespace Web.AutoMapperMappingActions
{
    public class SetUserIdentityAction : IMappingAction<object, UserIdentity>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SetUserIdentityAction(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public void Process(object source, UserIdentity destination)
        {
            var userClaims = _httpContextAccessor.HttpContext.User.Claims;

            destination.CurrentUserId = userClaims.FirstOrDefault(c => c.Type == UserClaimsNames.USER_ID)?.Value?.ToString()?.ToNullableInt();
            destination.CurrentPatientId = userClaims.FirstOrDefault(c => c.Type == UserClaimsNames.PATIENT_ID)?.Value?.ToString()?.ToNullableInt();
            destination.CurrentDoctorId = userClaims.FirstOrDefault(c => c.Type == UserClaimsNames.DOCTOR_ID)?.Value?.ToString()?.ToNullableInt();
            destination.CurrentRoles = userClaims.Where(c => c.Type == ClaimTypes.Role)?.Select(r => r.Value)?.ToList() ?? new List<string>();
        }
    }
}
