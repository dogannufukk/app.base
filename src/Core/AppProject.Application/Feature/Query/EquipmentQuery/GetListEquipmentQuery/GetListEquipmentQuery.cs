using AppProject.Application.Dtos;
using AppProject.Application.ResultModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Feature.Query.EquipmentQuery.GetListEquipmentQuery
{
    public class GetListEquipmentQuery : IRequest<IDataResult<List<ListEquipmentDto>>>
    {
    }
}
