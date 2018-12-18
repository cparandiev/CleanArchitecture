using Application.Interfaces.Repositories;
using Domain.Entities.DoctorAggregate;

namespace Persistence.Repositories
{
    public class DoctorRepository : EfRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(Context dbContext)
            : base(dbContext) { }
    }
}
