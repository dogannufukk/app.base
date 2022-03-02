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
    public class LogExceptionRepository : RepositoryBase<LogException>, ILogExceptionRepository
    {
        public LogExceptionRepository(DbContext context) : base(context)
        {
        }
    }
}
