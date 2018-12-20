using Application.Features.Doctor.Commands.SetWeeklyWorkingTime;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Models.BindingModels;

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

        [HttpPost]
        public async Task<IActionResult> WeeklyWorkingTime([FromBody]DoctorWeeklyWorkingTimeBm model)
        {
            var setWeeklyWorkingTimeCommand = _autoMapper.Map<SetWeeklyWorkingTimeCommand>(model);
            await Mediator.Send(setWeeklyWorkingTimeCommand);
            
            return Ok();
        }
    }
}
