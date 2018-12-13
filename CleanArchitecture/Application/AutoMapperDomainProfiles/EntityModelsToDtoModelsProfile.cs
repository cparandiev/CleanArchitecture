using Application.Features.Users.Models;
using Application.Models;
using AutoMapper;
using Domain.Entities.UserAggregate;
using System;

namespace Application.AutoMapperDomainProfiles
{
    public class EntityModelsToDtoModelsProfile : Profile
    {
        public EntityModelsToDtoModelsProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserRole, RoleDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => Enum.GetName((src.Role.Value.GetType()), src.Role.Value)));
        }
    }
}
