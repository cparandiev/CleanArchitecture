using Domain.Entities.UserAggregate;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>, IAsyncRepository<User>
    {
    }
}
