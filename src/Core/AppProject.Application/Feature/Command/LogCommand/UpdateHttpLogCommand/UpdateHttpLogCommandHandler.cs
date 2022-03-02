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

namespace AppProject.Application.Feature.Command.LogCommand.UpdateHttpLogCommand
{
    public class UpdateHttpLogCommandHandler : IRequestHandler<UpdateHttpLogCommand, IResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateHttpLogCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IResult> Handle(UpdateHttpLogCommand request, CancellationToken cancellationToken)
        {
            var httpLog = unitOfWork.LogHttpRepository.GetAsync(x => x.ConnectionId == request.ConnectionId).Result;
            if (httpLog == null)
                return new ErrorResult("data.not.found");
            else
            {
                httpLog.UpdatedTime = DateTime.Now;
                httpLog.ResponseBody = request.ResponseBody;
                httpLog.TotalProcessTime = request.TotalProcessTime;
                unitOfWork.LogHttpRepository.Update(httpLog);
                var result = await unitOfWork.SaveChangesAsync();
                if (result == 1)
                    return new SuccessResult();
                else
                    return new ErrorResult();
            }
        }
    }
}
