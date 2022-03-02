using AppProject.Domain.Common.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Domain.Entity
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }
        public DateTime? DateOfSupply { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UsageRate { get; set; }
        public Guid ClinicId { get; set; } 

        [ForeignKey("ClinicId")]
        public virtual Clinic Clinic { get; set; }
    }
}
