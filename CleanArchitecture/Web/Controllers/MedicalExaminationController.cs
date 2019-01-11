using Application.Features.Doctor.Commands.AccomplishMedicalExamination;
using Application.Features.Doctor.Commands.ReviewMedicalExamination;
using Application.Features.Patient.Commands.RequestMedicalExamination;
using AutoMapper;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Models.BindingModels;

namespace Web.Controllers
{
    [Authorize]
    public class MedicalExaminationController : BaseController
    {
        private readonly IMapper _autoMapper;

        public MedicalExaminationController(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }

        [HttpPost]
        [Authorize(Roles = nameof(Role.Patient))]
        public async Task<IActionResult> RequestMedicalExamination([FromBody]RequestMedicalExaminationBm model)
        {
            var requestMedicalExaminationCommand = _autoMapper.Map<RequestMedicalExaminationCommand>(model);

            await Mediator.Send(requestMedicalExaminationCommand);

            return Ok();
        }


        [HttpPost("{requestId:int}/review")]
        [Authorize(Roles = nameof(Role.Doctor))]
        public async Task<IActionResult> ReviewMedicalExamination([FromRoute]int? requestId, [FromBody]ReviewMedicalExaminationBm model)
        {
            var approveMedicalExaminationCommand = _autoMapper.Map<ReviewMedicalExaminationCommand>(model, opts => opts.Items[nameof(ReviewMedicalExaminationCommand.RequestId)] = requestId);

            await Mediator.Send(approveMedicalExaminationCommand);

            return Ok();
        }

        [HttpPost("{requestId:int}/accomplish")]
        [Authorize(Roles = nameof(Role.Doctor))]
        public async Task<IActionResult> AccomplishMedicalExamination([FromRoute]int? requestId, [FromBody]AccomplishMedicalExaminationBm model)
        {
            var accomplishMedicalExaminationCommand = _autoMapper.Map<AccomplishMedicalExaminationCommand>(model, opts => opts.Items[nameof(AccomplishMedicalExaminationCommand.RequestId)] = requestId);

            await Mediator.Send(accomplishMedicalExaminationCommand);

            return Ok();
        }
    }
}
