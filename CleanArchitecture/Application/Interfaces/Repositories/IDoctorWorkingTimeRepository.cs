using Domain.Entities.DoctorAggregate;

namespace Application.Interfaces.Repositories
{
    public interface IDoctorWorkingTimeRepository : IRepository<DoctorWorkingTime>, IAsyncRepository<DoctorWorkingTime>
    {
    }
}
