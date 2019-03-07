using Domain.Entities.BodyExaminationResultAggregate;

namespace Application.Interfaces.Repositories
{
    public interface IBodyExaminationResultRepository : IRepository<BodyExaminationResult>, IAsyncRepository<BodyExaminationResult>
    {
    }
}
