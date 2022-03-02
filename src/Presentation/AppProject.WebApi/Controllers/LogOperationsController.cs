using AppProject.Application.Feature.Command.LogCommand.CreateHttpLogCommand;
using AppProject.Application.Feature.Query.LogQuery.GetListExceptionLogQuery;
using AppProject.Application.Feature.Query.LogQuery.GetListHttpLogQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppProject.WebApi.Controllers
{
    [Route("api/log")]
    [ApiController]
    public class LogOperationsController : ControllerBase
    {
        IMediator _mediator;
        public LogOperationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("http/list")]
        public async Task<IActionResult> GetListLogHttp()
        {
            return Ok(await _mediator.Send(new GetListHttpLogQuery()));
        }
        [HttpGet("exception/list")]
        public async Task<IActionResult> GetListLogException()
        {
            return Ok(await _mediator.Send(new GetListExceptionLogQuery()));
        }
    }
}
