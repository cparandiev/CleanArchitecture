﻿using Application.AutoMapperDomainProfiles.Converters;
using Application.Features.Patient.Commands.CreatePatient;
using Application.Features.Patient.Commands.LoginPatient;
using Application.Features.Users.Commands.CreateUser;
using AutoMapper;
using Domain.Enums;
using Web.Models.BindingModels;

namespace Web.AutoMapperDomainProfiles
{
    public class BindingModelsToRequestModelsProfile : Profile
    {
        public BindingModelsToRequestModelsProfile()
        {
            CreateMap<RegisterPatientBm, CreateUserCommand>();
            CreateMap<RegisterPatientBm, CreatePatientCommand>();
            CreateMap<LoginPatientBm, LoginPatientCommand>();

            CreateMap<string, Gender>()
                .ConvertUsing<StringToEnumConverter<Gender>>();

            CreateMap<string, Blood>()
                .ConvertUsing<StringToEnumConverter<Blood>>();
        }
    }
}
