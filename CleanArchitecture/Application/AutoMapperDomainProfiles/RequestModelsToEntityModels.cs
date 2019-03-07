using Application.Features.BodyExamination.Commands.AddBloodOxygenLevelExamination;
using Application.Features.BodyExamination.Commands.AddBloodPressureExamination;
using Application.Features.BodyExamination.Commands.AddBodyTemperatureExamination;
using Application.Features.BodyExamination.Commands.AddPulseRateExamination;
using Application.Features.BodyExamination.Models;
using Application.Features.Doctor.Commands.AccomplishMedicalExamination;
using Application.Features.Doctor.Commands.CreateDoctor;
using Application.Features.Doctor.Models;
using Application.Features.Patient.Commands.CreatePatient;
using Application.Features.Patient.Commands.RequestMedicalExamination;
using Application.Features.Users.Commands.CreateUser;
using AutoMapper;
using Domain.Entities.BodyExaminationResultAggregate;
using Domain.Entities.DoctorAggregate;
using Domain.Entities.MedicalExaminationRequestAggregate;
using Domain.Entities.MedicalExaminationResultAggregate;
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

            #region MedicalExaminationRequest mappings
            CreateMap<RequestMedicalExaminationCommand, MedicalExaminationRequest>()
                .ForMember(dest => dest.IsApproved, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.IsAccomplished, opt => opt.MapFrom(src => false));

            CreateMap<AccomplishMedicalExaminationCommand, MedicalExaminationResult>();
            #endregion

            #region BodyExaminationResult mappings
            CreateMap<AddBloodOxygenLevelExaminationCommand, BloodOxygenLevelExaminationDto>();
            CreateMap<AddBloodOxygenLevelExaminationCommand, BodyExaminationResult>()
                .ForMember(dest => dest.BloodOxygenLevel, opt => opt.MapFrom(src => src));

            CreateMap<AddBodyTemperatureExaminationCommand, BodyTemperatureExaminationDto>();
            CreateMap<AddBodyTemperatureExaminationCommand, BodyExaminationResult>()
                .ForMember(dest => dest.BodyTemperature, opt => opt.MapFrom(src => src));

            CreateMap<AddPulseRateExaminationCommand, PulseRateExaminationDto>();
            CreateMap<AddPulseRateExaminationCommand, BodyExaminationResult>()
                .ForMember(dest => dest.PulseRate, opt => opt.MapFrom(src => src));

            CreateMap<AddBloodPressureExaminationCommand, BloodPressureExamination>();
            CreateMap<AddBloodPressureExaminationCommand, BodyExaminationResult>()
                .ForMember(dest => dest.BloodPressure, opt => opt.MapFrom(src => src));
            #endregion
        }
    }
}
