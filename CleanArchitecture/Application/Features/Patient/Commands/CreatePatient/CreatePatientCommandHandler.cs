﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Specifications.RoleSpecifications;
using AutoMapper;
using Domain.Entities.UserAggregate;
using Domain.Enums;
using MediatR;

namespace Application.Features.Patient.Commands.CreatePatient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, int>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public CreatePatientCommandHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<int> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var userEntity = _context.Users.GetById(request.UserId);
            var patientRole = _context.Roles.GetSingleBySpec(new RoleByValueSpecifications(Domain.Enums.Role.Patient));
            
            userEntity.UserRoles = new HashSet<UserRole>{
                new UserRole{ Role = patientRole }
            };
            var patientEntity = new Domain.Entities.PatientAggregate.Patient() {
                User = userEntity
            };

            await _context.Patients.AddAsync(patientEntity);
            await _context.CompleteAsync();

            return patientEntity.Id;
        }
    }
}
