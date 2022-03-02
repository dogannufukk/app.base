using AppProject.Domain.Common.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Domain.Entity
{
    public class LogException : BaseEntity
    {
        public int StatusCode { get; set; }
        public string ExceptionMessage { get; set; }
        public string Url { get; set; }
        public string RequestBody { get; set; }
        public string ConnectionId { get; set; }
    }
}
