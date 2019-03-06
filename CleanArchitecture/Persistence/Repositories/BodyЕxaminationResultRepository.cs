using Application.Interfaces.Repositories;
using Domain.Entities.BodyЕxaminationResultAggregate;

namespace Persistence.Repositories
{
    public class BodyЕxaminationResultRepository : EfRepository<BodyЕxaminationResult>, IBodyЕxaminationResultRepository
    {
        public BodyЕxaminationResultRepository(Context dbContext)
            : base(dbContext) { }
    }
}
