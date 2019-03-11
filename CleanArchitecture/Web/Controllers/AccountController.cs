using System.Threading.Tasks;
using Application.Features.Doctor.Commands.CreateDoctor;
using Application.Features.Doctor.Commands.LoginDoctor;
using Application.Features.Patient.Commands.CreatePatient;
using Application.Features.Patient.Commands.LoginPatient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models.BindingModels;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("register/patient")]
        public async Task<IActionResult> RegisterPatient([FromBody]RegisterPatientBm model)
        {
            var createPatientCommand = AutoMapper.Map<CreatePatientCommand>(model);
            
            var patient = await Mediator.Send(createPatientCommand);

            return await LoginPatient(AutoMapper.Map<LoginPatientBm>(model));
        }

        [AllowAnonymous]
        [HttpPost("login/patient")]
        public async Task<IActionResult> LoginPatient([FromBody]LoginPatientBm model)
        {
            var loginUserCommand = AutoMapper.Map<LoginPatientCommand>(model);

            var patientDto = await Mediator.Send(loginUserCommand);
            
            var loggedUserVm = AutoMapper.Map<LoggedPatientViewModel>(patientDto);

            return Ok(loggedUserVm);
        }

        [AllowAnonymous]
        [HttpPost("register/doctor")]
        public async Task<IActionResult> RegisterDoctor([FromBody]RegisterDoctorBm model)
        {
            var createDoctorCommand = AutoMapper.Map<CreateDoctorCommand>(model);

            var doctor = await Mediator.Send(createDoctorCommand);

            return await LoginDoctor(AutoMapper.Map<LoginDoctorBm>(model));
        }

        [AllowAnonymous]
        [HttpPost("login/doctor")]
        public async Task<IActionResult> LoginDoctor([FromBody]LoginDoctorBm model)
        {
            var loginDoctorCommand = AutoMapper.Map<LoginDoctorCommand>(model);

            var doctorDto = await Mediator.Send(loginDoctorCommand);
            
            var loggedUserVm = AutoMapper.Map<LoggedDoctorViewModel>(doctorDto);

            return Ok(loggedUserVm);
        }
    }
}
