using Application.Interfaces.Repositories;
using Domain.Entities.DoctorAggregate;

namespace Persistence.Repositories
{
    public class DoctorWorkingTimeRepository : EfRepository<DoctorWorkingTime>, IDoctorWorkingTimeRepository
    {
        public DoctorWorkingTimeRepository(Context dbContext)
            : base(dbContext) { }
    }
}
