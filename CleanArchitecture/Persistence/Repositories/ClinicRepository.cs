using Application.Interfaces.Repositories;
using Domain.Entities.ClinicAggregate;

namespace Persistence.Repositories
{
    public class ClinicRepository : EfRepository<Clinic>, IClinicRepository
    {
        public ClinicRepository(Context dbContext)
            : base(dbContext) { }
    }
}
