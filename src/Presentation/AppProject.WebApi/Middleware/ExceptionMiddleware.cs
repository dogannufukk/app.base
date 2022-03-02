using AppProject.Application.Feature.Command.LogCommand.CreateLogExceptionCommand;
using AppProject.Domain.Entity;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AppProject.WebApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IMediator mediator,IMapper mapper)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, mediator,mapper);
            }
        }

        private  Task HandleExceptionAsync(HttpContext context, Exception ex, IMediator mediator,IMapper mapper)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var statusCode = context.Response.StatusCode;
            var requestBodyStream = new MemoryStream();
            var originalRequestBody = context.Request.Body;


            context.Request.Body.CopyToAsync(requestBodyStream);
            requestBodyStream.Seek(0, SeekOrigin.Begin);

            var url = UriHelper.GetDisplayUrl(context.Request);
            var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();

            var logExceptionCommandObject = new CreateLogExceptionCommand()
            {
                ExceptionMessage = ex.Message,
                RequestBody = requestBodyText,
                StatusCode = statusCode,
                Url = url,
                ConnectionId = context.Connection.Id

            };
            mediator.Send(logExceptionCommandObject);


            return context.Response.WriteAsync(ex.Message);
        }
    }
}
