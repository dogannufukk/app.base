using AppProject.Application.ResultModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Feature.Command.EquipmentCommand.CreateEquipmentCommand
{
    public class CreateEquipmentCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public DateTime? DateOfSupply { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UsageRate { get; set; }
        public Guid ClinicId { get; set; }

    }
}
