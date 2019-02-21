using Application.Features.Clinic.Models;
using Application.Interfaces;
using Application.Specifications.ClinicSpecifications;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Clinic.Queries.GetAllClinics
{
    public class GetAllClinicsQueryHandler : IRequestHandler<GetAllClinicsQuery, List<ClinicDto>>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public GetAllClinicsQueryHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<List<ClinicDto>> Handle(GetAllClinicsQuery request, CancellationToken cancellationToken)
        {
            var clinics = await _context.Clinics.ListAsync(new ClinicsWithAddressAndDoctorsSpecification());

            return _autoMapper.Map<List<ClinicDto>>(clinics);
        }
    }
}
