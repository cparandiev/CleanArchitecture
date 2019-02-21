using Application.Features.Patient.Models;
using Application.Features.Users.Commands.CreateUser;
using MediatR;

namespace Application.Features.Patient.Commands.CreatePatient
{
    public class CreatePatientCommand : IRequest<PatientDto>
    {
        public CreateUserCommand CreateUserCommand { get; set; }
    }
}
