using Domain.Entities.PatientAggregate;
using Domain.Entities.UserAggregate;

namespace Application.Interfaces.Repositories
{
    public interface IPatientRepository : IRepository<Patient>, IAsyncRepository<Patient>
    {
    }
}
