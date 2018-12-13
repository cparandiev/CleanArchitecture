using Application.Interfaces.Repositories;
using Domain.Entities.UserAggregate;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(Context dbContext) 
            : base(dbContext){}
    }
}
