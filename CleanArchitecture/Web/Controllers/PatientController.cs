using Application.Features.Patient.Commands.RequestMedicalExamination;
using Application.Features.Patient.Queries.GetPatientMedicalExaminations;
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

        [HttpGet("{patientId:int}/MedicalExaminations")]
        [AllowAnonymous]
        // [Authorize(Roles = nameof(Role.Patient))] // todo
        //[TypeFilter(typeof(OwnerFilter))]
        public async Task<IActionResult> GetPatienMedicalExaminations(PatientMedicalExaminationsBm model)
        {
            var getPatienMedicalExaminationsQuery = _autoMapper.Map<GetPatientMedicalExaminationsQuery>(model);

            var medicalExaminations = await Mediator.Send(getPatienMedicalExaminationsQuery);

            return Ok(medicalExaminations);
        }
    }
}
