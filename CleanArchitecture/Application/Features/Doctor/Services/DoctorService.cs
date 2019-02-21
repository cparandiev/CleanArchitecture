using System.Threading.Tasks;
using Application.Features.Doctor.Commands.CreateDoctor;
using Application.Features.Doctor.Services.Interfaces;
using Application.Interfaces;
using Application.Specifications.RoleSpecifications;
using AutoMapper;
using Domain.Entities.DoctorAggregate;
using Domain.Entities.UserAggregate;

namespace Application.Features.Doctor.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public DoctorService(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<Domain.Entities.DoctorAggregate.Doctor> CreateDoctor(User user, CreateDoctorCommand createDoctorCommand)
        {
            var doctorRole = _context.Roles.GetSingleBySpec(new RoleByValueSpecifications(Domain.Enums.Role.Doctor));

            user.UserRoles.Add(new UserRole { Role = doctorRole });

            var doctor = _autoMapper.Map<Domain.Entities.DoctorAggregate.Doctor>(createDoctorCommand);
            doctor.User = user;

            await _context.Doctors.AddAsync(doctor);

            return doctor;
        }
    }
}
