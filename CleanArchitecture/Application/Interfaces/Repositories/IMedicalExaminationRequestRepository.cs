namespace Application.Interfaces.Repositories
{
    public interface IMedicalExaminationRequestRepository : IRepository<Domain.Entities.MedicalExaminationRequestAggregate.MedicalExaminationRequest>, IAsyncRepository<Domain.Entities.MedicalExaminationRequestAggregate.MedicalExaminationRequest>
    {
    }
}
