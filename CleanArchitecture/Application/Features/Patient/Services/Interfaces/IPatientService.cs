using Application.Features.Patient.Commands.CreatePatient;
using Domain.Entities.UserAggregate;
using System.Threading.Tasks;

namespace Application.Features.Patient.Services.Interfaces
{
    public interface IPatientService
    {
        Task<Domain.Entities.PatientAggregate.Patient> CreatePatient(User user, CreatePatientCommand createPatientCommand);
    }
}
