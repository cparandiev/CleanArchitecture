using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Queries.GetUsers;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Filters;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : BaseController
    {
        private readonly IMapper _autoMapper;

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public SampleDataController(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<WeatherForecast>> WeatherForecasts()
        {
            var rng = new Random();

            ///
            //var firstUsersDtos = await Mediator.Send(new GetUsersQuery());
            //var firstUsersVMs = _autoMapper.Map<List<UserViewModel>>(firstUsersDtos);


            //await Mediator.Send(new CreateUserCommand() { Username = "new2" });

            //var secondUsersDtos = await Mediator.Send(new GetUsersQuery());
            //var secondUsersVMs = _autoMapper.Map<List<UserViewModel>>(secondUsersDtos);
            ///

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> One()
        {
            return NoContent();
        }

        [Authorize(Roles = "Patient")]
        [HttpGet("[action]")]
        public async Task<ActionResult> Two()
        {
            return NoContent();
        }

        [Authorize(Roles = "Doctor")]
        [Authorize(Roles = "Patient")]
        [HttpGet("[action]")]
        public async Task<ActionResult> Three()
        {
            return NoContent();
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
