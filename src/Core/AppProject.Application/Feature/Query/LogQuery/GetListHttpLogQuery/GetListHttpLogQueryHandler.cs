using AppProject.Application.Dtos;
using AppProject.Application.ResultModel;
using AppProject.Application.UnitOfWork;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppProject.Application.Feature.Query.LogQuery.GetListHttpLogQuery
{
    public class GetListHttpLogQueryHandler : IRequestHandler<GetListHttpLogQuery, IDataResult<List<HttpLogViewDto>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetListHttpLogQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<List<HttpLogViewDto>>> Handle(GetListHttpLogQuery request, CancellationToken cancellationToken)
        {
            var listHttpLog = await unitOfWork.LogHttpRepository.GetAllAsync();
            var dtoList = mapper.Map<List<HttpLogViewDto>>(listHttpLog);
            return new SuccessDataResult<List<HttpLogViewDto>>(dtoList, String.Format("{0} kayıt getirildi.", dtoList.Count));
        }
    }
}
