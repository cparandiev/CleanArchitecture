using Application.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        IPatientRepository Patients { get; }

        IRoleRepository Roles { get; }

        IDoctorRepository Doctors { get; }

        IClinicRepository Clinics { get; }

        IMedicalExaminationRequestRepository MedicalExaminationRequests { get; }

        Task CompleteAsync();

        Task CompleteAsync(CancellationToken cancellationToken);
        
        void Complete();
    }
}
