using Domain.Entities.MedicalExaminationRequestAggregate;

namespace Application.Interfaces.Repositories
{
    public interface IMedicalExaminationRequestRepository : IRepository<MedicalExaminationRequest>, IAsyncRepository<MedicalExaminationRequest>
    {
    }
}
