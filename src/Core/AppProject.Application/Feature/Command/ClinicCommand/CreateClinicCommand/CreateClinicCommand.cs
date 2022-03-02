using AppProject.Application.ResultModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Feature.Command.ClinicCommand.CreateClinicCommand
{
    public class CreateClinicCommand : IRequest<IResult>
    {
        public string Name { get; set; }
    }
}
