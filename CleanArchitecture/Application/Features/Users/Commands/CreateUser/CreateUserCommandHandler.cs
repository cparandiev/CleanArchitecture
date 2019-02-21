using System.Threading;
using System.Threading.Tasks;
using Application.Features.Users.Models;
using Application.Features.Users.Services.Interfaces;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public CreateUserCommandHandler(IUserService userService, IUnitOfWork context, IMapper autoMapper)
        {
            _userService = userService;
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _userService.CreateUser(request);

            await _context.CompleteAsync();

            return _autoMapper.Map<UserDto>(entity);
        }
    }
}
