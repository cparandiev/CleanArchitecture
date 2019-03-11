using Application.AutoMapperDomainProfiles.Converters;
using Application.Features.BodyExamination.Commands.AddBloodOxygenLevelExamination;
using Application.Features.BodyExamination.Commands.AddBloodPressureExamination;
using Application.Features.BodyExamination.Commands.AddBodyTemperatureExamination;
using Application.Features.BodyExamination.Commands.AddPulseRateExamination;
using Application.Features.Doctor.Commands.AccomplishMedicalExamination;
using Application.Features.Doctor.Commands.CreateDoctor;
using Application.Features.Doctor.Commands.DeleteWorkingTime;
using Application.Features.Doctor.Commands.ReviewMedicalExamination;
using Application.Features.Doctor.Commands.SetWeeklyWorkingTime;
using Application.Features.Doctor.Models;
using Application.Features.Doctor.Queries.GetDoctorMedicalExaminations;
using Application.Features.Doctor.Queries.GetDoctorPatient;
using Application.Features.Patient.Commands.CreatePatient;
using Application.Features.Patient.Commands.LoginPatient;
using Application.Features.Patient.Commands.RequestMedicalExamination;
using Application.Features.Patient.Queries.GetPatienBodyExaminations;
using Application.Features.Patient.Queries.GetPatientMedicalExaminations;
using Application.Features.Users.Commands.CreateUser;
using Application.Models;
using AutoMapper;
using Domain.Enums;
using Web.AutoMapperMappingActions;
using Web.Models.BindingModels;

namespace Web.AutoMapperDomainProfiles
{
    public class BindingModelsToRequestModelsProfile : Profile
    {
        public BindingModelsToRequestModelsProfile()
        {
            #region Patient mappings
            CreateMap<RegisterPatientBm, CreateUserCommand>();
            CreateMap<RegisterPatientBm, CreatePatientCommand>()
                .ForMember(dest => dest.CreateUserCommand, opt => opt.MapFrom(src => src));
            CreateMap<LoginPatientBm, LoginPatientCommand>();
            #endregion

            #region Doctor mappings
            CreateMap<RegisterDoctorBm, CreateUserCommand>();
            CreateMap<RegisterDoctorBm, CreatePatientCommand>()
                .ForMember(dest => dest.CreateUserCommand, opt => opt.MapFrom(src => src));
            CreateMap<RegisterDoctorBm, CreateDoctorCommand>()
                .ForMember(dest => dest.CreatePatientCommand, opt => opt.MapFrom(src => src));

            CreateMap<DoctorWeeklyWorkingTimeBm, SetWeeklyWorkingTimeCommand>()
                .IncludeBase<object, UserIdentity>()
                .AfterMap((src, dest, cntx) => {
                    dest.DoctorId = (int?)cntx.Items[nameof(SetWeeklyWorkingTimeCommand.DoctorId)];
                });

            CreateMap<DeleteWorkingTimeBm, DeleteWorkingTimeCommand> ()
                .IncludeBase<object, UserIdentity>();

            CreateMap<GetDoctorPatientsBm, GetDoctorPatientsQuery> ()
                .IncludeBase<object, UserIdentity>();
            #endregion

            #region Medical Examination mappings
            CreateMap<RequestMedicalExaminationBm, RequestMedicalExaminationCommand>()
                .IncludeBase<object, UserIdentity>();

            CreateMap<AccomplishMedicalExaminationBm, AccomplishMedicalExaminationCommand>()
                .IncludeBase<object, UserIdentity>()
                .AfterMap((src, dest, cntx) => {
                    dest.RequestId = (int?)cntx.Items[nameof(AccomplishMedicalExaminationCommand.RequestId)];
                });

            CreateMap<ReviewMedicalExaminationBm, ReviewMedicalExaminationCommand>()
                .IncludeBase<object, UserIdentity>()
                .AfterMap((src, dest, cntx) => {
                    dest.RequestId = (int?)cntx.Items[nameof(ReviewMedicalExaminationCommand.RequestId)];
                });

            CreateMap<PatientMedicalExaminationsBm, GetPatientMedicalExaminationsQuery>()
                .IncludeBase<object, UserIdentity>();

            CreateMap<DoctorMedicalExaminationsBm, GetDoctorMedicalExaminationsQuery>()
                .IncludeBase<object, UserIdentity>();
            #endregion

            #region Body Examination mappings
            CreateMap<AddBloodOxygenLevelExaminationBm, AddBloodOxygenLevelExaminationCommand>()
                .IncludeBase<object, UserIdentity>();

            CreateMap<AddBodyTemperatureExaminationBm, AddBodyTemperatureExaminationCommand>()
                .IncludeBase<object, UserIdentity>();

            CreateMap<AddPulseRateExaminationBm, AddPulseRateExaminationCommand>()
                .IncludeBase<object, UserIdentity>();

            CreateMap<AddBloodPressureExaminationBm, AddBloodPressureExaminationCommand>()
                .IncludeBase<object, UserIdentity>();

            CreateMap<PatienBodyExaminationsBm, GetPatienBodyExaminationsQuery>()
                .IncludeBase<object, UserIdentity>();
            #endregion

            CreateMap<string, Gender>()
                .ConvertUsing<StringToEnumConverter<Gender>>();

            CreateMap<string, Blood>()
                .ConvertUsing<StringToEnumConverter<Blood>>();

            CreateMap<WorkingTimeBm, WorkingTimeUnit>();

            CreateMap<object, UserIdentity>()
                .AfterMap<SetUserIdentityAction>();
        }
    }
}
