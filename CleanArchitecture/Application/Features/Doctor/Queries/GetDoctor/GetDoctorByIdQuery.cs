using Application.Features.Doctor.Models;
using MediatR;

namespace Application.Features.Doctor.Queries.GetDoctor
{
    public class GetDoctorByIdQuery : IRequest<DoctorDto>
    {
        public int UserId { get; set; }
    }
}
