using AppProject.Application.ResultModel;
using AppProject.Application.UnitOfWork;
using AppProject.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppProject.Application.Feature.Query.LogQuery.GetByIdHttpLogQuery
{
    public class GetByIdHttpLogQueryHandler : IRequestHandler<GetByIdHttpLogQuery, IDataResult<LogHttp>>
    {
        IUnitOfWork _unitOfWork;
        
        public GetByIdHttpLogQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<LogHttp>> Handle(GetByIdHttpLogQuery request, CancellationToken cancellationToken)
        {
            var httpLog = await _unitOfWork.LogHttpRepository.GetAsync(x => x.ConnectionId == request.ConnectionId);
            if (httpLog != null)
                return new SuccessDataResult<LogHttp>(httpLog);
            else
                return new ErrorDataResult<LogHttp>();

        }
    }
}
