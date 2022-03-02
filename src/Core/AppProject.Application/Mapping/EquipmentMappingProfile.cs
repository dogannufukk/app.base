using AppProject.Application.Feature.Command.EquipmentCommand.CreateEquipmentCommand;
using AppProject.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Mapping
{
    public class EquipmentMappingProfile : Profile
    {
        public EquipmentMappingProfile()
        {
            CreateMap<CreateEquipmentCommand, Equipment>().ReverseMap();
        }
    }
}
