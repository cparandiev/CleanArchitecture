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
        [HttpGet]
        public async Task<IActionResult> GetAllClinics()
        {
            var clinicsDto = await Mediator.Send(new GetAllClinicsQuery());

            var clinicsViewModel = AutoMapper.Map<List<ClinicViewModel>>(clinicsDto);

            return Ok(clinicsViewModel);
        }
    }
}
