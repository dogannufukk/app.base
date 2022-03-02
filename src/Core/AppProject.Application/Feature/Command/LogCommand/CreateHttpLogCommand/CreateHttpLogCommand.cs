using AppProject.Application.ResultModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Feature.Command.LogCommand.CreateHttpLogCommand
{
    public class CreateHttpLogCommand :IRequest<IResult>
    {
        public string LogException { get; set; }
        public string BodyText { get; set; }
        public int StatusCode { get; set; }
        public string Url { get; set; }
        public string ConnectionId { get; set; }
        public string TraceId { get; set; }
        public string IPAddress { get; set; }
        public string MethodType { get; set; }
    }
}
