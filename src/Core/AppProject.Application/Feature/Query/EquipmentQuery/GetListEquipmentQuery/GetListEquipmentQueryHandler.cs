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

namespace AppProject.Application.Feature.Query.EquipmentQuery.GetListEquipmentQuery
{
    public class GetListEquipmentQueryHandler : IRequestHandler<GetListEquipmentQuery, IDataResult<List<ListEquipmentDto>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetListEquipmentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IDataResult<List<ListEquipmentDto>>> Handle(GetListEquipmentQuery request, CancellationToken cancellationToken)
        {
            var list = await unitOfWork.EquipmentRepository
                .GetListAsyncWithIncludeParams(x => !x.IsDeleted, new List<string>() { "Clinic" });
            var dtoList = (from x in list
                           select new ListEquipmentDto()
                           {
                               ClinicName = x.Clinic?.Name ?? "",
                               EquipmentId = x.Id,
                               EquipmentName = x.Name,
                               Quantity = x.Quantity,
                               UnitPrice = x.UnitPrice,
                               UsageRate = x.UsageRate
                           }).ToList();
            var equipmentDtoList = mapper.Map<List<ListEquipmentDto>>(dtoList);
            return new SuccessDataResult<List<ListEquipmentDto>>(equipmentDtoList, String.Format("{0} kayıt getirildi.", dtoList.Count));
        }
    }
}
