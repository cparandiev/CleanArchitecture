using Application.Features.Users.Commands.CreateUser;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.UserAggregate;

namespace Application.AutoMapperDomainProfiles
{
    public class RequestModelsToEntityModels : Profile
    {
        public RequestModelsToEntityModels()
        {
            CreateMap<CreateUserCommand, User>();
        }
    }
}
