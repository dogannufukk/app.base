using AppProject.Application.Feature.Command.LogCommand.UpdateHttpLogCommand;
using AppProject.Application.Feature.Query.LogQuery.GetByIdHttpLogQuery;
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
    public class ResponseMiddleware
    {
        private readonly RequestDelegate _next;
        public ResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Api'lere yapılan isteklerin response bilgilerini yakalar ve veri tabanına kaydeder.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, IMediator mediator)
        {
            var bodyStream = context.Response.Body;
            var responseBodyStream = new MemoryStream();
            context.Response.Body = responseBodyStream;
            await _next(context);
            responseBodyStream.Seek(0, SeekOrigin.Begin);
            var responseBody = new StreamReader(responseBodyStream).ReadToEnd();
            var url = UriHelper.GetDisplayUrl(context.Request);
            if (!url.Contains("/http/list"))
            {
                var getHttpLogRequest = new GetByIdHttpLogQuery() { ConnectionId = context.Connection.Id };
                var httpLog = await mediator.Send(getHttpLogRequest);

                TimeSpan totalRequestTime = DateTime.Now - httpLog.Data.CreatedTime;

                var updateHttpLogRequest = new UpdateHttpLogCommand()
                {
                    ConnectionId = context.Connection.Id,
                    ResponseBody = responseBody,
                    TotalProcessTime = totalRequestTime.Seconds.ToString() + " (sn)"
                };
                await mediator.Send(updateHttpLogRequest);

            }


            responseBodyStream.Seek(0, SeekOrigin.Begin);
            await responseBodyStream.CopyToAsync(bodyStream);


        }
    }
}
