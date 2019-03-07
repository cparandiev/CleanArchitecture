using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Repositories;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork(Context context, IUserRepository userRepository, IPatientRepository patientRepository, IRoleRepository rolesRepository, IDoctorRepository doctorsRepository, IClinicRepository clinicRepository,
            IMedicalExaminationRequestRepository medicalExaminationRequestsRepository, IDoctorWorkingTimeRepository doctorWorkingTimesRepository,
            IBodyExaminationResultRepository bodyExaminationResultRepository, IBodyExaminationTypeRepository bodyExaminationTypeRepository)
        {
            _context = context;
            Users = userRepository;
            Patients = patientRepository;
            Roles = rolesRepository;
            Doctors = doctorsRepository;
            Clinics = clinicRepository;
            MedicalExaminationRequests = medicalExaminationRequestsRepository;
            DoctorWorkingTimes = doctorWorkingTimesRepository;
            BodyExaminationResultRepository = bodyExaminationResultRepository;
            BodyExaminationTypeRepository = bodyExaminationTypeRepository;
        }

        public IUserRepository Users { get; }

        public IPatientRepository Patients { get; }

        public IRoleRepository Roles { get; }

        public IDoctorRepository Doctors { get; }

        public IClinicRepository Clinics { get; }

        public IMedicalExaminationRequestRepository MedicalExaminationRequests { get; }

        public IDoctorWorkingTimeRepository DoctorWorkingTimes { get; }

        public IBodyExaminationResultRepository BodyExaminationResultRepository { get; }

        public IBodyExaminationTypeRepository BodyExaminationTypeRepository { get; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CompleteAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
