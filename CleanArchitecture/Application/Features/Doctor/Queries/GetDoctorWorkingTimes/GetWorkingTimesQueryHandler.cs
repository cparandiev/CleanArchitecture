using Application.Features.Doctor.Models;
using Application.Interfaces;
using Application.Specifications.DoctorSpecifications;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Doctor.Queries.GetDoctorWorkingTimes
{
    public class GetWorkingTimesQueryHandler : IRequestHandler<GetWorkingTimesQuery, List<DoctorWorkingTimeDto>>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public GetWorkingTimesQueryHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public Task<List<DoctorWorkingTimeDto>> Handle(GetWorkingTimesQuery request, CancellationToken cancellationToken)
        {
            var entity = _context.Doctors.GetSingleBySpec(new DoctorWithUserPropsSpecifications(request.DoctorId));

            var workingTimes = _autoMapper.Map<List<DoctorWorkingTimeDto>>(entity.WorkingTimes);

            return Task.FromResult(workingTimes);
        }
    }
}
