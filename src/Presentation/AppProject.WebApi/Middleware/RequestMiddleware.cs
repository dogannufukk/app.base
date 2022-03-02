using AppProject.Application.Feature.Command.LogCommand.CreateHttpLogCommand;
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
using System.Threading.Tasks;

namespace AppProject.WebApi.Middleware
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// Api'lere yapılan isteklerin request bilgisini yakalar ve veri tabanına kaydeder.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, IMapper mapper, IMediator mediator)
        {

            var requestBodyStream = new MemoryStream();
            var originalRequestBody = context.Request.Body;

            await context.Request.Body.CopyToAsync(requestBodyStream);
            requestBodyStream.Seek(0, SeekOrigin.Begin);

            var url = UriHelper.GetDisplayUrl(context.Request);
            var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();
            
            if(!url.Contains("/http/list"))
            {
                var command = new CreateHttpLogCommand()
                {
                    IPAddress = context.Connection.RemoteIpAddress.ToString(),
                    BodyText = requestBodyText,
                    MethodType = context.Request.Method,
                    TraceId = context.TraceIdentifier,
                    Url = url,
                    ConnectionId = context.Connection.Id,
                };
                await mediator.Send(command);
            }
            


            requestBodyStream.Seek(0, SeekOrigin.Begin);
            context.Request.Body = requestBodyStream;

            await _next(context);
            context.Request.Body = originalRequestBody;



        }
    }
}
