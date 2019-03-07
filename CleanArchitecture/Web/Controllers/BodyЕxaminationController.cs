using Application.Features.BodyЕxamination.Commands.AddBloodOxygenLevelExamination;
using Application.Features.BodyЕxamination.Commands.AddBloodPressureExamination;
using Application.Features.BodyЕxamination.Commands.AddBodyTemperatureExamination;
using Application.Features.BodyЕxamination.Commands.AddPulseRateExamination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Models.BindingModels;

namespace Web.Controllers
{
    [Authorize]
    public class BodyЕxaminationController : BaseController
    {
        [HttpPost("bloodoxygen")]
        [AllowAnonymous] // todo
        public async Task<IActionResult> AddBloodOxygenLevelExamination([FromBody]AddBloodOxygenLevelExaminationBm model)
        {
            var addBloodOxygenLevelExaminationCommand = AutoMapper.Map<AddBloodOxygenLevelExaminationCommand>(model);

            await Mediator.Send(addBloodOxygenLevelExaminationCommand);

            return Ok();
        }

        [HttpPost("temperature")]
        [AllowAnonymous] // todo
        public async Task<IActionResult> AddBodyTemperatureExamination([FromBody]AddBodyTemperatureExaminationBm model)
        {
            var addBodyTemperatureExaminationCommand = AutoMapper.Map<AddBodyTemperatureExaminationCommand>(model);

            await Mediator.Send(addBodyTemperatureExaminationCommand);

            return Ok();
        }

        [HttpPost("pulserate")]
        [AllowAnonymous] // todo
        public async Task<IActionResult> AddPulseRateExamination([FromBody]AddPulseRateExaminationBm model)
        {
            var addPulseRateExaminationCommand = AutoMapper.Map<AddPulseRateExaminationCommand>(model);

            await Mediator.Send(addPulseRateExaminationCommand);

            return Ok();
        }

        [HttpPost("bloodpressure")]
        [AllowAnonymous] // todo
        public async Task<IActionResult> AddBloodPressureExamination([FromBody]AddBloodPressureExaminationBm model)
        {
            var addBloodPressureExaminationCommand = AutoMapper.Map<AddBloodPressureExaminationCommand>(model);

            await Mediator.Send(addBloodPressureExaminationCommand);

            return Ok();
        }
    }
}