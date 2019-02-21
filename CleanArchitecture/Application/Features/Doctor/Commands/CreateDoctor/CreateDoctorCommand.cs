using Application.Features.Doctor.Models;
using Application.Features.Patient.Commands.CreatePatient;
using MediatR;

namespace Application.Features.Doctor.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<DoctorDto>
    {
        public string Username { get; set; }

        public string Summary { get; set; }

        public int? ClinicId { get; set; }

        public CreatePatientCommand CreatePatientCommand { get; set; }
    }
}
