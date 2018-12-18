using Application.Features.Doctor.Commands.CreateDoctor;
using Application.Features.Patient.Commands.CreatePatient;
using Application.Features.Users.Commands.CreateUser;
using AutoMapper;
using Domain.Entities.DoctorAggregate;
using Domain.Entities.PatientAggregate;
using Domain.Entities.UserAggregate;

namespace Application.AutoMapperDomainProfiles
{
    public class RequestModelsToEntityModels : Profile
    {
        public RequestModelsToEntityModels()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<CreatePatientCommand, Patient>();
            CreateMap<CreateDoctorCommand, Doctor>();
        }
    }
}
