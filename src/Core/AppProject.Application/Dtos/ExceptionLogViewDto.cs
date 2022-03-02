using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Application.Dtos
{
    public class ExceptionLogViewDto
    {
        public Guid Id { get; set; }
        public string ExceptionMessage { get; set; }
        public string Url { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
