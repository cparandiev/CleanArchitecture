using Application.Features.Users.Commands.CreateUser;
using Domain.Entities.UserAggregate;
using System.Threading.Tasks;

namespace Application.Features.Users.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(CreateUserCommand createUserCommand);
    }
}
