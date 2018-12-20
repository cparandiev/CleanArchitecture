using Application.Features.Doctor.Commands.CreateDoctor;
using Application.Features.Doctor.Models;
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
            #region User mappings
            CreateMap<CreateUserCommand, User>();
            #endregion

            #region Patient mappings
            CreateMap<CreatePatientCommand, Patient>();
            #endregion

            #region Doctor mappings
            CreateMap<CreateDoctorCommand, Doctor>();
            CreateMap<WorkingTimeUnit, DoctorWorkingTime>();
            #endregion
        }
    }
}
