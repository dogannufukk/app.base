using AppProject.Application.Feature.Command.EquipmentCommand.CreateEquipmentCommand;
using AppProject.Application.Feature.Query.EquipmentQuery.GetListEquipmentQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppProject.WebApi.Controllers
{
    [Route("api/equipment")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IMediator mediator;

        public EquipmentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> CreateEquipment(CreateEquipmentCommand cmd)
        {
            return Ok(await mediator.Send(cmd));
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetListEquipment()
        {
            return Ok(await mediator.Send(new GetListEquipmentQuery()));
        }

    }
}
