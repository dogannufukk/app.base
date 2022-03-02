using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Dtos
{
    public class ListEquipmentDto 
    {
        public Guid EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UsageRate { get; set; }
        public string ClinicName { get; set; }
    }
}
