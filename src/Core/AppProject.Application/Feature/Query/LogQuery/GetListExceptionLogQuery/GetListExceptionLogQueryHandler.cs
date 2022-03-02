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

namespace AppProject.Application.Feature.Query.LogQuery.GetListExceptionLogQuery
{
    public class GetListExceptionLogQueryHandler : IRequestHandler<GetListExceptionLogQuery, IDataResult<List<ExceptionLogViewDto>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetListExceptionLogQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IDataResult<List<ExceptionLogViewDto>>> Handle(GetListExceptionLogQuery request, CancellationToken cancellationToken)
        {
            var list = await unitOfWork.LogExceptionRepository.GetAllAsync();
            var dtoList = mapper.Map<List<ExceptionLogViewDto>>(list);
            return new SuccessDataResult<List<ExceptionLogViewDto>>(dtoList,String.Format("{0} adet kayıt getirildi.",dtoList.Count));
        }
    }
}
