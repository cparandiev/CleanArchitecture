using Application.Interfaces.Repositories;
using Domain.Entities.BodyExaminationResultAggregate;

namespace Persistence.Repositories
{
    public class BodyExaminationResultRepository : EfRepository<BodyExaminationResult>, IBodyExaminationResultRepository
    {
        public BodyExaminationResultRepository(Context dbContext)
            : base(dbContext) { }
    }
}
