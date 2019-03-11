using Application.Features.Patient.Models;
using Application.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Web.Constants.Claim;
using Web.Models.ViewModels;

namespace Web.AutoMapperMappingActions
{
    public class SetPatientJWTAction : IMappingAction<PatientDto, LoggedPatientViewModel>
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public SetPatientJWTAction(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        public void Process(PatientDto source, LoggedPatientViewModel destination)
        {
            var claims = new List<Claim>() {
                new Claim (UserClaimsNames.USER_ID, source.User.Id.ToString()),
                new Claim (UserClaimsNames.PATIENT_ID, source.Id.ToString())
            };

            destination.JWT = _authService.CreateJWT(_configuration["SecurityKey"], claims.ToArray(), _configuration["Issuer"], _configuration["Audience"], DateTime.Now.AddYears(1)); //todo

            destination.Roles = destination.Roles.Select(r => { r = r.ToLower(); return r; }).ToList();
        }
    }
}
