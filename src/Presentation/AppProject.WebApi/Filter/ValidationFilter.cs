using AppProject.Application.Feature.Query.LogQuery.GetListHttpLogQuery;
using AppProject.Application.GlobalModel;
using AppProject.Application.ResultModel;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppProject.WebApi.Filter
{
    public class ValidationFilter : IAsyncActionFilter
    {
        IMapper _mapper;
        IMediator _mediator;
        public ValidationFilter(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage))
                    .ToArray();
                var validationErrorList = new List<ValidationResultModel>();
                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ValidationResultModel()
                        {
                            FieldName = error.Key,
                            ErrorMessage = subError,
                        };
                        validationErrorList.Add(errorModel);
                    }
                }
                var errorResult = new ErrorDataResult<List<ValidationResultModel>>(validationErrorList,"validation.error","validation.error.occured");
                context.Result = new BadRequestObjectResult(errorResult);
                return;
            }
            await next();

        }
    }
}
