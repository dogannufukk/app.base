using AppProject.Domain.Common.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Domain.Entity
{
    public class LogHttp : BaseEntity
    {
        public string IpAddress { get; set; }
        public string TraceId { get; set; }
        public string ConnectionId { get; set; }
        public string MethodType { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public string RequestUrl { get; set; }
        public string TotalProcessTime { get; set; }
    }
}
