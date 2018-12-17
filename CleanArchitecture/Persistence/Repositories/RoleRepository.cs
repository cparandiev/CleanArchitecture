using Application.Interfaces.Repositories;
using Domain.Entities.UserAggregate;

namespace Persistence.Repositories
{
    public class RoleRepository : EfRepository<Role>, IRoleRepository
    {
        public RoleRepository(Context dbContext)
            : base(dbContext) { }
    }
}
