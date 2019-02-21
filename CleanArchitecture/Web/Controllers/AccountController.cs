using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Features.Doctor.Commands.CreateDoctor;
using Application.Features.Doctor.Commands.LoginDoctor;
using Application.Features.Patient.Commands.CreatePatient;
using Application.Features.Patient.Commands.LoginPatient;
using Application.Features.Patient.Queries.GetPatient;
using Application.Features.Users.Commands.CreateUser;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Web.Constants.Claim;
using Web.Models.BindingModels;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _autoMapper;
        private readonly IAuthService _authService;

        public AccountController(IConfiguration configuration, IMapper autoMapper, IAuthService authService)
        {
            _configuration = configuration;
            _autoMapper = autoMapper;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("register/patient")]
        public async Task<IActionResult> RegisterPatient([FromBody]RegisterPatientBm model)
        {
            var createPatientCommand = _autoMapper.Map<CreatePatientCommand>(model);
            
            var patient = await Mediator.Send(createPatientCommand);

            return await LoginPatient(_autoMapper.Map<LoginPatientBm>(model));
        }

        [AllowAnonymous]
        [HttpPost("login/patient")]
        public async Task<IActionResult> LoginPatient([FromBody]LoginPatientBm model)
        {
            var loginUserCommand = _autoMapper.Map<LoginPatientCommand>(model);
            var patientDto = await Mediator.Send(loginUserCommand);
            
            var loggedUserVm = _autoMapper.Map<LoggedPatientViewModel>(patientDto);
            loggedUserVm.JWT = CreateJWT(new List<Claim>() {
                new Claim (UserClaimsNames.USER_ID, patientDto.User.Id.ToString()),
                new Claim (UserClaimsNames.PATIENT_ID, patientDto.Id.ToString())
            });

            return Ok(loggedUserVm);
        }

        [AllowAnonymous]
        [HttpPost("register/doctor")]
        public async Task<IActionResult> RegisterDoctor([FromBody]RegisterDoctorBm model)
        {
            var createDoctorCommand = _autoMapper.Map<CreateDoctorCommand>(model);

            var doctor = await Mediator.Send(createDoctorCommand);

            return await LoginDoctor(_autoMapper.Map<LoginDoctorBm>(model));
        }

        [AllowAnonymous]
        [HttpPost("login/doctor")]
        public async Task<IActionResult> LoginDoctor([FromBody]LoginDoctorBm model)
        {
            var loginDoctorCommand = _autoMapper.Map<LoginDoctorCommand>(model);
            var doctorDto = await Mediator.Send(loginDoctorCommand);
            
            var loggedUserVm = _autoMapper.Map<LoggedDoctorViewModel>(doctorDto);
            loggedUserVm.JWT = CreateJWT(new List<Claim>() {
                new Claim (UserClaimsNames.USER_ID, doctorDto.User.Id.ToString()),
                new Claim (UserClaimsNames.DOCTOR_ID, doctorDto.Id.ToString()),
            });

            return Ok(loggedUserVm);
        }

        [NonAction]
        private string CreateJWT(List<Claim> claims) => _authService.CreateJWT(_configuration["SecurityKey"], claims.ToArray(), _configuration["Issuer"], _configuration["Audience"], DateTime.Now.AddYears(1)); //todo
    }
}
