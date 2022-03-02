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

namespace AppProject.Application.Feature.Command.ClinicCommand.CreateClinicCommand
{
    public class CreateClinicCommandHandler : IRequestHandler<CreateClinicCommand, IResult>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateClinicCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<IResult> Handle(CreateClinicCommand request, CancellationToken cancellationToken)
        {
            var clinic = mapper.Map<Clinic>(request);
            unitOfWork.ClinicRepository.AddAsync(clinic);
            var saveResult = await unitOfWork.SaveChangesAsync();
            if (saveResult == 1)
                return new SuccessResult("record.successfully.created");
            else
                return new ErrorResult("error.occured");

        }
    }
}
