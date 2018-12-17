using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.UserAggregate;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;
        private readonly ISecurePasswordHasher _securePasswordHasher;

        public CreateUserCommandHandler(IUnitOfWork context, IMapper autoMapper, ISecurePasswordHasher securePasswordHasher)
        {
            _context = context;
            _autoMapper = autoMapper;
            _securePasswordHasher = securePasswordHasher;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _autoMapper.Map<User>(request);
            entity.PasswordHash = _securePasswordHasher.Hash(request.Password);

            await _context.Users.AddAsync(entity);
            await _context.CompleteAsync();

            return entity.Id;
        }
    }
}
