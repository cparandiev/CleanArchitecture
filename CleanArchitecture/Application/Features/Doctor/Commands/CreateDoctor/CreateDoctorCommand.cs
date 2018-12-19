using MediatR;

namespace Application.Features.Doctor.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<int>
    {
        public int? UserId { get; set; }

        public string Summary { get; set; }

        public int? ClinicId { get; set; }
    }
}
