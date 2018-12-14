using Application.Features.Patient.Commands.CreatePatient;
using Application.Features.Users.Commands.CreateUser;
using AutoMapper;
using Domain.Enums;
using System;
using Web.Models.BindingModels;

namespace Web.AutoMapperDomainProfiles
{
    public class BindingModelsToRequestModelsProfile : Profile
    {
        public BindingModelsToRequestModelsProfile()
        {
            CreateMap<RegisterPatientBm, CreateUserCommand>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse(typeof(Gender), src.Gender)))
                .ForMember(dest => dest.Blood, opt => opt.MapFrom(src => Enum.Parse(typeof(Blood), src.Blood)));
            CreateMap<RegisterPatientBm, CreatePatientCommand>();
        }
    }
}
