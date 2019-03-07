using Domain.Entities.BodyExaminationResultAggregate;

namespace Application.Interfaces.Repositories
{
    public interface IBodyExaminationTypeRepository : IRepository<BodyExaminationType>, IAsyncRepository<BodyExaminationType>
    {
    }
}
