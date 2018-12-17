using Application.Features.Patient.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Patient.Commands.LoginPatient
{
    public class LoginPatientCommand : IRequest<PatientDto>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
