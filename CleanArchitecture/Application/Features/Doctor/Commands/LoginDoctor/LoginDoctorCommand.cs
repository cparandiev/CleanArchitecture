using Application.Features.Doctor.Models;
using MediatR;

namespace Application.Features.Doctor.Commands.LoginDoctor
{
    public class LoginDoctorCommand : IRequest<DoctorDto>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
