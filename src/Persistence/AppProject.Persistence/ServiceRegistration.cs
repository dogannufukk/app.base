using AppProject.Application.UnitOfWork;
using AppProject.Persistence.UnitOfWorkArea;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServiceRegistration(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
