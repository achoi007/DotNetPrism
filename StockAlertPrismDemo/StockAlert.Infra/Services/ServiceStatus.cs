using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlert.Infra.Services
{
    public class ServiceStatus
    {
        public enum StatusCode
        {
            Down,
            Up,
            Alert,
            Error,
            Custom,
        };

        public string Name { get; set; }

        public string Message { get; set; }

        public int Code { get; set; }

        public StatusCode Status { get; set; }
    }
}
