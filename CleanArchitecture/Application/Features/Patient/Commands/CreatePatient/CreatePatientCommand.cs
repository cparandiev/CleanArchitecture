using MediatR;

namespace Application.Features.Patient.Commands.CreatePatient
{
    public class CreatePatientCommand : IRequest<int>
    {
        public int UserId { get; set; }
    }
}
