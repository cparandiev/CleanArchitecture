using Application.Features.Doctor.Commands.SetWeeklyWorkingTime;
using AutoMapper;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Models.BindingModels;
using Web.Filters;

namespace Web.Controllers
{
    [Authorize]
    public class DoctorController : BaseController
    {
        private readonly IMapper _autoMapper;

        public DoctorController(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }

        [HttpPost("{doctorId}/WeeklyWorkingTime")]
        [Authorize(Roles = nameof(Role.Doctor))]
        [TypeFilter(typeof(OwnerFilter))]
        public async Task<IActionResult> WeeklyWorkingTime([FromRoute] int? doctorId, [FromBody]DoctorWeeklyWorkingTimeBm model)
        {
            model.DoctorId = doctorId;
            var setWeeklyWorkingTimeCommand = _autoMapper.Map<SetWeeklyWorkingTimeCommand>(model);
            await Mediator.Send(setWeeklyWorkingTimeCommand);

            return Ok();
        }

        
        [HttpGet("one/{patientId}")]
        [TypeFilter(typeof(OwnerFilter))]
        public async Task<IActionResult> Test(int? patientId)
        {
            return Ok();
        }
        
        //[HttpPost("two/{patientId}")]
        //[TypeFilter(typeof(OwnerFilter))]
        //public async Task<IActionResult> Test2(DoctorWeeklyWorkingTimeBm model)
        //{
        //    return Ok();
        //}
    }
}
