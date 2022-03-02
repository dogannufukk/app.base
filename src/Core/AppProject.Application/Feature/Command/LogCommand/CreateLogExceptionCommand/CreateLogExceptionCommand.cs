using AppProject.Application.ResultModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Feature.Command.LogCommand.CreateLogExceptionCommand
{
    public class CreateLogExceptionCommand : IRequest<IResult>
    {
        public string ExceptionMessage { get; set; }
        public string RequestBody { get; set; }
        public int StatusCode { get; set; }
        public string Url { get; set; }
        public string ConnectionId { get; set; }
    }
}
