using Application.Features.Clinic.Queries.GetAllClinics;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class ClinicController : BaseController
    {
        private readonly IMapper _autoMapper;

        public ClinicController(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }

        [HttpGet]
        [AllowAnonymous] // todo
        public async Task<IActionResult> GetAllClinics()
        {
            var clinicsDto = await Mediator.Send(new GetAllClinicsQuery());

            var clinicsViewModel = _autoMapper.Map<List<ClinicViewModel>>(clinicsDto);

            return Ok(clinicsViewModel);
        }
    }
}
