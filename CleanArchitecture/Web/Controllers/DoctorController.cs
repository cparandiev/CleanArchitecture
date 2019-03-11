using Application.Features.Doctor.Commands.SetWeeklyWorkingTime;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Models.BindingModels;
using Application.Features.Doctor.Queries.GetDoctorWorkingTimes;
using Application.Features.Doctor.Commands.DeleteWorkingTime;
using Application.Features.Doctor.Queries.GetDoctorMedicalExaminations;
using Web.Models.ViewModels;
using System.Collections.Generic;
using Application.Features.Doctor.Queries.GetDoctorPatient;

namespace Web.Controllers
{
    [Authorize]
    public class DoctorController : BaseController
    {
        [HttpGet("{doctorId:int}/patients")]
        [Authorize(Roles = nameof(Role.Doctor))]
        public async Task<IActionResult> GetDoctorPatients(GetDoctorPatientsBm model)
        {
            var getDoctorPatientsQuery = AutoMapper.Map<GetDoctorPatientsQuery>(model);

            var doctorPatients = await Mediator.Send(getDoctorPatientsQuery);

            return Ok(doctorPatients);
        }

        [HttpDelete("WorkingTime/{workingTimeId:int}")]
        [Authorize(Roles = nameof(Role.Doctor))]
        public async Task<IActionResult> DeleteWorkingTime(DeleteWorkingTimeBm workingTime)
        {
            var deleteWorkingTimeCommand = AutoMapper.Map<DeleteWorkingTimeCommand>(workingTime);

            await Mediator.Send(deleteWorkingTimeCommand);

            return Ok();
        }

        [HttpGet("{doctorId:int}/WorkingTimes")]
        public async Task<IActionResult> GetWorkingTimes(DoctorWorkingTimesBm model)
        {
            var getWorkingTimesQuery = AutoMapper.Map<GetWorkingTimesQuery>(model);

            var workingTimes = await Mediator.Send(getWorkingTimesQuery);

            return Ok(workingTimes);
        }

        [HttpPost("{doctorId:int}/WeeklyWorkingTime")]
        [Authorize(Roles = nameof(Role.Doctor))]
        public async Task<IActionResult> WeeklyWorkingTime([FromRoute] int? doctorId, [FromBody]DoctorWeeklyWorkingTimeBm model)
        {
            var setWeeklyWorkingTimeCommand = AutoMapper.Map<SetWeeklyWorkingTimeCommand>(model, opts => opts.Items[nameof(SetWeeklyWorkingTimeCommand.DoctorId)] = doctorId.Value);
            
            await Mediator.Send(setWeeklyWorkingTimeCommand);

            return Ok();
        }

        [HttpGet("{doctorId:int}/MedicalExaminations")]
        [Authorize(Roles = nameof(Role.Doctor))]
        public async Task<IActionResult> WeeklyWorkingTime(DoctorMedicalExaminationsBm model)
        {
            var getDoctorMedicalExaminationsQuery = AutoMapper.Map<GetDoctorMedicalExaminationsQuery>(model);

            var medicalExaminationsDtos = await Mediator.Send(getDoctorMedicalExaminationsQuery);

            var medicalExaminationsVms = AutoMapper.Map<List<MedicalExaminationRequestViewModel>>(medicalExaminationsDtos);

            return Ok(medicalExaminationsVms);
        }
    }
}
