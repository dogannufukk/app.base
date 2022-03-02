using AppProject.Application.ResultModel;
using AppProject.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Feature.Query.LogQuery.GetByIdHttpLogQuery
{
    public class GetByIdHttpLogQuery : IRequest<IDataResult<LogHttp>>
    {
        public string ConnectionId { get; set; }
    }
}
