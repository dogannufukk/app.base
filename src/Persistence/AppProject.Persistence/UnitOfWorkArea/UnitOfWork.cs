using AppProject.Application.Repository;
using AppProject.Application.UnitOfWork;
using AppProject.Persistence.Context;
using AppProject.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Persistence.UnitOfWorkArea
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        public ILogHttpRepository LogHttpRepository { get; private set; }
        public ILogExceptionRepository LogExceptionRepository { get; private set; }
        public IEquipmentRepository EquipmentRepository { get; private set; }
        public IClinicRepository ClinicRepository { get; private set; }


        public UnitOfWork(MsSqlDbContext dbContext)
        {
            _dbContext = dbContext;
            LogHttpRepository = new LogHttpRepository(_dbContext);
            LogExceptionRepository = new LogExceptionRepository(_dbContext);
            ClinicRepository = new ClinicRepository(_dbContext);
            EquipmentRepository = new EquipmentRepository(_dbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();

        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
