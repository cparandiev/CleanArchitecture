using Application.Features.Users.Models;
using Application.Models;
using AutoMapper;
using Web.Models.ViewModels;

namespace Web.AutoMapperDomainProfiles
{
    public class DtoModelsToViewModelsProfile : Profile
    {
        public DtoModelsToViewModelsProfile()
        {
            CreateMap<UserDto, UserViewModel>();
            CreateMap<RoleDto, RoleViewModel>();
        }
    }
}
