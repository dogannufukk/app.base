using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AppProject.Application.Mapping;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace AppProject.Application
{
    public static class ServiceRegistration 
    {
        public static void AddApplicationServiceRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new LogObjectMappingProfile());
                mc.AddProfile(new ClinicMappingProfile());
                mc.AddProfile(new EquipmentMappingProfile());
            
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
