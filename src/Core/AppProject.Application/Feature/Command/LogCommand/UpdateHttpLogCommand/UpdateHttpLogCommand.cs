using AppProject.Application.ResultModel;
using AppProject.Application.UnitOfWork;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Feature.Command.LogCommand.UpdateHttpLogCommand
{
    public class UpdateHttpLogCommand : IRequest<IResult>
    {
        public string ConnectionId { get; set; }
        public string ResponseBody { get; set; }
        public string TotalProcessTime { get; set; }



    }
}
