using AppProject.Application.ResultModel;
using AppProject.Application.UnitOfWork;
using AppProject.Domain.Entity;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppProject.Application.Feature.Command.EquipmentCommand.CreateEquipmentCommand
{
    public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand, IResult>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateEquipmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IResult> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var equipment = mapper.Map<Equipment>(request);
            unitOfWork.EquipmentRepository.AddAsync(equipment);
            var saveResult = await unitOfWork.SaveChangesAsync();
            if (saveResult == 1)
                return new SuccessResult("record.successfully.created");
            else
                return new ErrorResult("error.occured");

        }
    }
}
