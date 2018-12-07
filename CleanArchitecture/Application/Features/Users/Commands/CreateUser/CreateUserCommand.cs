using MediatR;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string Username { get; set; }
    }
}
