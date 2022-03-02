using AppProject.Application.Repository;
using AppProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Persistence.Repository
{
    public class LogHttpRepository : RepositoryBase<LogHttp>, ILogHttpRepository
    {
        public LogHttpRepository(DbContext context) : base(context)
        {
        }
    }
}
