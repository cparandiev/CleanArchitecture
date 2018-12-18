using Domain.Entities.PatientAggregate;

namespace Application.Interfaces.Repositories
{
    public interface IPatientRepository : IRepository<Patient>, IAsyncRepository<Patient>
    {
    }
}
