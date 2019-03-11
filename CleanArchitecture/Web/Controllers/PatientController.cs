using Application.Features.Patient.Commands.RequestMedicalExamination;
using Application.Features.Patient.Queries.GetPatienBodyExaminations;
using Application.Features.Patient.Queries.GetPatient;
using Application.Features.Patient.Queries.GetPatientMedicalExaminations;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Models.BindingModels;

namespace Web.Controllers
{
    [Authorize]
    public class PatientController : BaseController
    {
        [HttpGet("{patientId:int}/info")]
        public async Task<IActionResult> GetPatienInfo(PatienInfoBm model)
        {
            var GetPatientByIdQuery = AutoMapper.Map<GetPatientByIdQuery>(model);

            var patientInfo = await Mediator.Send(GetPatientByIdQuery);

            return Ok(patientInfo);
        }

        [HttpPost("{patientId:int}/RequestMedicalExamination")]
        [Authorize(Roles = nameof(Role.Patient))]
        public async Task<IActionResult> RequestMedicalExamination([FromRoute] int? patientId, [FromBody]RequestMedicalExaminationBm model)
        {
            var requestMedicalExaminationCommand = AutoMapper.Map<RequestMedicalExaminationCommand>(model, opts => opts.Items[nameof(RequestMedicalExaminationCommand.PatientId)] = patientId.Value);

            await Mediator.Send(requestMedicalExaminationCommand);

            return Ok();
        }

        [HttpGet("{patientId:int}/MedicalExaminations")]
        public async Task<IActionResult> GetPatienMedicalExaminations(PatientMedicalExaminationsBm model)
        {
            var getPatienMedicalExaminationsQuery = AutoMapper.Map<GetPatientMedicalExaminationsQuery>(model);

            var medicalExaminations = await Mediator.Send(getPatienMedicalExaminationsQuery);

            return Ok(medicalExaminations);
        }

        [HttpGet("{patientId:int}/BodyExaminations")]
        public async Task<IActionResult> GetPatienBodyExaminations(PatienBodyExaminationsBm model)
        {
            var getPatienBodyExaminationsQuery = AutoMapper.Map<GetPatienBodyExaminationsQuery>(model);

            var bodyExaminations = await Mediator.Send(getPatienBodyExaminationsQuery);

            return Ok(bodyExaminations);
        }
    }
}
