using Application.Features.Patient.Commands.RequestMedicalExamination;
using Application.Features.Patient.Queries.GetPatienBodyЕxaminations;
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
        [HttpPost("{patientId:int}/RequestMedicalExamination")]
        [Authorize(Roles = nameof(Role.Patient))]
        //[TypeFilter(typeof(OwnerFilter))]
        public async Task<IActionResult> RequestMedicalExamination([FromRoute] int? patientId, [FromBody]RequestMedicalExaminationBm model)
        {
            var requestMedicalExaminationCommand = AutoMapper.Map<RequestMedicalExaminationCommand>(model, opts => opts.Items[nameof(RequestMedicalExaminationCommand.PatientId)] = patientId.Value);

            await Mediator.Send(requestMedicalExaminationCommand);

            return Ok();
        }

        [HttpGet("{patientId:int}/MedicalExaminations")]
        [AllowAnonymous]
        // [Authorize(Roles = nameof(Role.Patient))] // todo
        //[TypeFilter(typeof(OwnerFilter))]
        public async Task<IActionResult> GetPatienMedicalExaminations(PatientMedicalExaminationsBm model)
        {
            var getPatienMedicalExaminationsQuery = AutoMapper.Map<GetPatientMedicalExaminationsQuery>(model);

            var medicalExaminations = await Mediator.Send(getPatienMedicalExaminationsQuery);

            return Ok(medicalExaminations);
        }

        [HttpGet("{patientId:int}/BodyЕxaminations")]
        [AllowAnonymous]
        // [Authorize(Roles = nameof(Role.Patient))] // todo
        public async Task<IActionResult> GetPatienBodyЕxaminations(PatienBodyЕxaminationsBm model)
        {
            var getPatienBodyЕxaminationsQuery = AutoMapper.Map<GetPatienBodyЕxaminationsQuery>(model);

            var bodyЕxaminations = await Mediator.Send(getPatienBodyЕxaminationsQuery);

            return Ok(bodyЕxaminations);
        }
    }
}
