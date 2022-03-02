using AppProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Persistence.Context
{
    public class MsSqlDbContext:DbContext
    {
        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<LogHttp> LogHttp { get; set; }
        public DbSet<LogException> LogException { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
    }
}
