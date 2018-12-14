using Application.Interfaces.Repositories;
using Domain.Entities.PatientAggregate;

namespace Persistence.Repositories
{
    public class PatientRepository : EfRepository<Patient>, IPatientRepository
    {
        public PatientRepository(Context dbContext)
            : base(dbContext) { }
    }
}
