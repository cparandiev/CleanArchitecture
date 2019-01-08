using Application.Interfaces.Repositories;
using Domain.Entities.MedicalExaminationRequestAggregate;

namespace Persistence.Repositories
{
    public class MedicalExaminationRequestRepository : EfRepository<MedicalExaminationRequest>, IMedicalExaminationRequestRepository
    {
        public MedicalExaminationRequestRepository(Context dbContext)
            : base(dbContext) { }
    }
}
