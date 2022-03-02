using AppProject.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ILogHttpRepository LogHttpRepository { get; }
        ILogExceptionRepository LogExceptionRepository { get; }
        IClinicRepository ClinicRepository { get; }
        IEquipmentRepository EquipmentRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
