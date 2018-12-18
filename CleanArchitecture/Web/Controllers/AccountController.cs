﻿using System;
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

        [HttpGet("{id}")]
        [AllowAnonymous]
        public string RequestToken(int id)
        {
            var claims = new[]
            {
                new Claim("userId", id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
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

            var patientVm = _autoMapper.Map<PatientViewModel>(patientDto);

            return Created($"/api/users/{userId}", patientVm);
        }

        [AllowAnonymous]
        [HttpPost("login/patient")]
        public async Task<IActionResult> LoginPatient([FromBody]LoginPatientBm model)
        {
            var loginUserCommand = _autoMapper.Map<LoginPatientCommand>(model);
            var patientDto = await Mediator.Send(loginUserCommand);
            
            var claims = new[]{
                new Claim("userId", patientDto.User.Id.ToString())
            };

            var jwt = _authService.CreateJWT(_configuration["SecurityKey"], claims, _configuration["Issuer"], _configuration["Audience"], DateTime.Now.AddMinutes(30));

            return Ok(jwt);
        }
    }
}
