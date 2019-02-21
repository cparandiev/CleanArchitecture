using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Services.Interfaces;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.UserAggregate;
using System.Threading.Tasks;

namespace Application.Features.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;
        private readonly ISecurePasswordHasher _securePasswordHasher;

        public UserService(IUnitOfWork context, IMapper autoMapper, ISecurePasswordHasher securePasswordHasher)
        {
            _context = context;
            _autoMapper = autoMapper;
            _securePasswordHasher = securePasswordHasher;
        }

        public async Task<User> CreateUser(CreateUserCommand request)
        {
            var entity = _autoMapper.Map<User>(request);
            entity.PasswordHash = _securePasswordHasher.Hash(request.Password);

            await _context.Users.AddAsync(entity);

            return entity;
        }
    }
}
