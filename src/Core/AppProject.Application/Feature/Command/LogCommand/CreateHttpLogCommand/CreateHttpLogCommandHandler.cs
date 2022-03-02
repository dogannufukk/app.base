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

namespace AppProject.Application.Feature.Command.LogCommand.CreateHttpLogCommand
{
    public class CreateHttpLogCommandHandler : IRequestHandler<CreateHttpLogCommand, IResult>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateHttpLogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(CreateHttpLogCommand request, CancellationToken cancellationToken)
        {
            var obj = mapper.Map<LogHttp>(request);
            unitOfWork.LogHttpRepository.AddAsync(obj);
            var result = await unitOfWork.SaveChangesAsync();
            if (result == 1)
                return new SuccessResult();
            else
                return new ErrorResult();
        }
    }
}
