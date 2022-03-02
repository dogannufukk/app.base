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

namespace AppProject.Application.Feature.Query.ClinicQuery.GetListClinicQuery
{
    public class GetListClinicQueryHandler : IRequestHandler<GetListClinicQuery, IDataResult<List<ListClinicDto>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetListClinicQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IDataResult<List<ListClinicDto>>> Handle(GetListClinicQuery request, CancellationToken cancellationToken)
        {
            var list = await unitOfWork.ClinicRepository.GetAllAsync(x => !x.IsDeleted);
            var dtoList = mapper.Map<List<ListClinicDto>>(list);
            return new SuccessDataResult<List<ListClinicDto>>(dtoList, String.Format("{0} kayıt getirildi.", dtoList.Count));

        }
    }
}
