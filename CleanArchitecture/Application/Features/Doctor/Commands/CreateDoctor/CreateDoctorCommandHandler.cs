using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Specifications.RoleSpecifications;
using AutoMapper;
using Domain.Entities.UserAggregate;
using Domain.Enums;
using MediatR;

namespace Application.Features.Doctor.Commands.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, int>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public CreateDoctorCommandHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<int> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var userEntity = _context.Users.GetById(request.UserId.Value);
            var doctorRole = _context.Roles.GetSingleBySpec(new RoleByValueSpecifications(Domain.Enums.Role.Doctor));

            userEntity.UserRoles.Add(new UserRole { Role = doctorRole });

            var doctorEntity = _autoMapper.Map<Domain.Entities.DoctorAggregate.Doctor>(request);

            await _context.Doctors.AddAsync(doctorEntity);
            await _context.CompleteAsync();

            return doctorEntity.Id;
        }
    }
}
