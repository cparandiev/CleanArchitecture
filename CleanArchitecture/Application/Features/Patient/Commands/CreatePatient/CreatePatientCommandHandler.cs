using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Patient.Models;
using Application.Features.Patient.Services.Interfaces;
using Application.Features.Users.Services.Interfaces;
using Application.Interfaces;
using Application.Specifications.RoleSpecifications;
using AutoMapper;
using Domain.Entities.UserAggregate;
using Domain.Enums;
using MediatR;

namespace Application.Features.Patient.Commands.CreatePatient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, PatientDto>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;

        public CreatePatientCommandHandler(IUnitOfWork context, IUserService userService, IPatientService patientService, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
            _userService = userService;
            _patientService = patientService;
        }

        public async Task<PatientDto> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.CreateUser(request.CreateUserCommand);
            var patient = await _patientService.CreatePatient(user, request);

            await _context.CompleteAsync();

            return _autoMapper.Map<PatientDto>(patient);
        }
    }
}
