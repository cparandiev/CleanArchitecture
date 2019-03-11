using Application.Features.Doctor.Models;
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
    public class SetDoctorJWTAction : IMappingAction<DoctorDto, LoggedDoctorViewModel>
    {

        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public SetDoctorJWTAction(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        public void Process(DoctorDto source, LoggedDoctorViewModel destination)
        {
            var claims = new List<Claim>() {
                new Claim (UserClaimsNames.USER_ID, source.User.Id.ToString()),
                new Claim (UserClaimsNames.DOCTOR_ID, source.Id.ToString())
            };

            destination.JWT = _authService.CreateJWT(_configuration["SecurityKey"], claims.ToArray(), _configuration["Issuer"], _configuration["Audience"], DateTime.Now.AddYears(1)); //todo

            destination.Roles = destination.Roles.Select(r => { r = r.ToLower(); return r; }).ToList();
        }
    }
}
