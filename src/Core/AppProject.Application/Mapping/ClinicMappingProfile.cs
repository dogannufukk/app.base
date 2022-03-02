using AppProject.Application.Dtos;
using AppProject.Application.Feature.Command.ClinicCommand.CreateClinicCommand;
using AppProject.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Mapping
{
    public class ClinicMappingProfile : Profile
    {
        public ClinicMappingProfile()
        {
            CreateMap<CreateClinicCommand, Clinic>().ReverseMap();
            CreateMap<ListClinicDto, Clinic>().ReverseMap();
            CreateMap<ListClinicDto, CreateClinicCommand>().ReverseMap();
        }
    }
}
