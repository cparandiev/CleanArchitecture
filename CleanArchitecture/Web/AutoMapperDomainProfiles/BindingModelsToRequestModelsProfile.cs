using Application.AutoMapperDomainProfiles.Converters;
using Application.Features.Doctor.Commands.AccomplishMedicalExamination;
using Application.Features.Doctor.Commands.CreateDoctor;
using Application.Features.Doctor.Commands.DeleteWorkingTime;
using Application.Features.Doctor.Commands.ReviewMedicalExamination;
using Application.Features.Doctor.Commands.SetWeeklyWorkingTime;
using Application.Features.Doctor.Models;
using Application.Features.Patient.Commands.CreatePatient;
using Application.Features.Patient.Commands.LoginPatient;
using Application.Features.Patient.Commands.RequestMedicalExamination;
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
            CreateMap<RegisterPatientBm, CreatePatientCommand>();
            CreateMap<LoginPatientBm, LoginPatientCommand>();
            #endregion

            #region Doctor mappings
            CreateMap<RegisterDoctorBm, CreateUserCommand>();
            CreateMap<RegisterDoctorBm, CreatePatientCommand>();
            CreateMap<RegisterDoctorBm, CreateDoctorCommand>();

            CreateMap<DoctorWeeklyWorkingTimeBm, SetWeeklyWorkingTimeCommand>()
                .IncludeBase<object, UserIdentity>()
                .AfterMap((src, dest, cntx) => {
                    dest.DoctorId = (int?)cntx.Items[nameof(SetWeeklyWorkingTimeCommand.DoctorId)];
                });

            CreateMap<DeleteWorkingTimeBm, DeleteWorkingTimeCommand> ()
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
