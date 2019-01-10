using Application.Features.Patient.Commands.RequestMedicalExamination;
using AutoMapper;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Filters;
using Web.Models.BindingModels;

namespace Web.Controllers
{
    [Authorize]
    public class PatientController : BaseController
    {
        private readonly IMapper _autoMapper;

        public PatientController(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }

        [HttpPost("{patientId:int}/RequestMedicalExamination")]
        [Authorize(Roles = nameof(Role.Patient))]
        //[TypeFilter(typeof(OwnerFilter))]
        public async Task<IActionResult> RequestMedicalExamination([FromRoute] int? patientId, [FromBody]RequestMedicalExaminationBm model)
        {
            var requestMedicalExaminationCommand = _autoMapper.Map<RequestMedicalExaminationCommand>(model, opts => opts.Items[nameof(RequestMedicalExaminationCommand.PatientId)] = patientId.Value);

            await Mediator.Send(requestMedicalExaminationCommand);

            return Ok();
        }
    }
}
