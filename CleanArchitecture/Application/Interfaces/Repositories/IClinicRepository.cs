using Domain.Entities.ClinicAggregate;

namespace Application.Interfaces.Repositories
{
    public interface IClinicRepository : IRepository<Clinic>, IAsyncRepository<Clinic>
    {
    }
}
