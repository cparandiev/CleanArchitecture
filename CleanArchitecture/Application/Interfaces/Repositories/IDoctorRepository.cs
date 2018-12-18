using Domain.Entities.DoctorAggregate;

namespace Application.Interfaces.Repositories
{
    public interface IDoctorRepository : IRepository<Doctor>, IAsyncRepository<Doctor>
    {
    }
}
