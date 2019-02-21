using Application.Features.Doctor.Commands.CreateDoctor;
using Domain.Entities.UserAggregate;
using System.Threading.Tasks;

namespace Application.Features.Doctor.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<Domain.Entities.DoctorAggregate.Doctor> CreateDoctor(User user, CreateDoctorCommand createDoctorCommand);
    }
}
