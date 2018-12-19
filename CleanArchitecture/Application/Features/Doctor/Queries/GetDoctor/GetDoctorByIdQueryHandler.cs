using System.Threading;
using System.Threading.Tasks;
using Application.Features.Doctor.Models;
using Application.Interfaces;
using Application.Specifications.DoctorSpecifications;
using AutoMapper;
using MediatR;

namespace Application.Features.Doctor.Queries.GetDoctor
{
    public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, DoctorDto>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public GetDoctorByIdQueryHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public Task<DoctorDto> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _context.Doctors.GetSingleBySpec(new DoctorWithUserPropsSpecifications(request.UserId));

            var doctorDto = _autoMapper.Map<DoctorDto>(entity);

            return Task.FromResult(doctorDto);
        }
    }
}
