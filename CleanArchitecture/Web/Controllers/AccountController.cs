using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Patient.Commands.CreatePatient;
using Application.Features.Patient.Commands.LoginPatient;
using Application.Features.Patient.Queries.GetPatient;
using Application.Features.Users.Commands.CreateUser;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Web.Models.BindingModels;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
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
            var createUserCommand = _autoMapper.Map<CreateUserCommand>(model);
            var userId = await Mediator.Send(createUserCommand);

            var createPatientCommand = _autoMapper.Map<CreatePatientCommand>(model);
            createPatientCommand.UserId = userId;
            var patientId = await Mediator.Send(createPatientCommand);

            var getPatientQuery = new GetPatientByIdQuery() { UserId = userId };
            var patientDto = await Mediator.Send(getPatientQuery);
            
            var loggedUserVm = _autoMapper.Map<LoggedUserViewModel>(patientDto);
            loggedUserVm = SignInUser(loggedUserVm);

            return Created($"/api/users/{userId}", loggedUserVm);
        }

        [AllowAnonymous]
        [HttpPost("login/patient")]
        public async Task<IActionResult> LoginPatient([FromBody]LoginPatientBm model)
        {
            var loginUserCommand = _autoMapper.Map<LoginPatientCommand>(model);
            var patientDto = await Mediator.Send(loginUserCommand);
            
            var loggedUserVm = _autoMapper.Map<LoggedUserViewModel>(patientDto);
            loggedUserVm = SignInUser(loggedUserVm);

            return Ok(loggedUserVm);
        }

        private LoggedUserViewModel SignInUser(LoggedUserViewModel loggedUserVm)
        {
            var claims = new[]{
                new Claim("userId", loggedUserVm.UserId.ToString())
            };

            loggedUserVm.JWT = _authService.CreateJWT(_configuration["SecurityKey"], claims, _configuration["Issuer"], _configuration["Audience"], DateTime.Now.AddMinutes(30));

            return loggedUserVm;
        }
    }
}
