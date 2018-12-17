using Domain.Entities.UserAggregate;

namespace Application.Interfaces.Repositories
{
    public interface IRoleRepository : IRepository<Role>, IAsyncRepository<Role>
    {
    }
}
