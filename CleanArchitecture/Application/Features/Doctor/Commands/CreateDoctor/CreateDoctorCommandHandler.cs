using System.Threading;
using System.Threading.Tasks;
using Application.Features.Doctor.Models;
using Application.Features.Doctor.Services.Interfaces;
using Application.Features.Patient.Services.Interfaces;
using Application.Features.Users.Services.Interfaces;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Doctor.Commands.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, DoctorDto>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        

        public CreateDoctorCommandHandler(IUnitOfWork context, IMapper autoMapper, IUserService userService,
            IPatientService patientService, IDoctorService doctorService)
        {
            _context = context;
            _autoMapper = autoMapper;
            _userService = userService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        public async Task<DoctorDto> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.CreateUser(request.CreatePatientCommand.CreateUserCommand);
            var patient = await _patientService.CreatePatient(user, request.CreatePatientCommand);
            var doctor = await _doctorService.CreateDoctor(user, request);

            await _context.CompleteAsync();

            return _autoMapper.Map<DoctorDto>(doctor);
        }
    }
}
