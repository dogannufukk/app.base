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

namespace AppProject.Application.Feature.Command.LogCommand.CreateLogExceptionCommand
{
    public class CreateLogExceptionCommandHandler : IRequestHandler<CreateLogExceptionCommand, IResult>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public CreateLogExceptionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> Handle(CreateLogExceptionCommand request, CancellationToken cancellationToken)
        {
            var logExceptionObject = _mapper.Map<LogException>(request);
            _unitOfWork.LogExceptionRepository.AddAsync(logExceptionObject);
            var result =await _unitOfWork.SaveChangesAsync();
            if (result == 1)
                return new SuccessResult();
            else
                return new ErrorResult();
        }
    }
}
