using AppProject.Application.Feature.Command.ClinicCommand.CreateClinicCommand;
using AppProject.Application.Feature.Query.ClinicQuery.GetListClinicQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppProject.WebApi.Controllers
{
    [Route("api/clinic")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        IMediator mediator;
        public ClinicController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateClinic(CreateClinicCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetListClinic()
        {
            return Ok(await mediator.Send(new GetListClinicQuery()));
        }

    }
}
