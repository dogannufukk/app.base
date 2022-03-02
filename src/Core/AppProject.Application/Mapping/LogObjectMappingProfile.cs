using AppProject.Application.Dtos;
using AppProject.Application.Feature.Command.LogCommand.CreateHttpLogCommand;
using AppProject.Application.Feature.Command.LogCommand.CreateLogExceptionCommand;
using AppProject.Application.Feature.Command.LogCommand.UpdateHttpLogCommand;
using AppProject.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Mapping
{
    public class LogObjectMappingProfile : Profile
    {
        public LogObjectMappingProfile()
        {
            CreateMap<LogHttp, CreateHttpLogCommand>()
                .ForMember(x => x.BodyText,y => y.MapFrom(a => a.RequestBody))
                .ForMember(x => x.Url,y => y.MapFrom(a => a.RequestUrl))
                .ReverseMap();
            CreateMap<LogHttp, UpdateHttpLogCommand>().ReverseMap();
            CreateMap<LogHttp, HttpLogViewDto>().ReverseMap();
            CreateMap<LogException, CreateLogExceptionCommand>().ReverseMap();
            CreateMap<LogException, ExceptionLogViewDto>().ReverseMap();


        }
    }
}
