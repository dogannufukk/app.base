using AppProject.Application.Dtos;
using AppProject.Application.ResultModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Feature.Query.LogQuery.GetListExceptionLogQuery
{
    public class GetListExceptionLogQuery : IRequest<IDataResult<List<ExceptionLogViewDto>>>
    {
    }
}
