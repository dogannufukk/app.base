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
    public class ClinicRepository : RepositoryBase<Clinic>,IClinicRepository
    {
        public ClinicRepository(DbContext context):base(context)
        {

        }
    }
}
