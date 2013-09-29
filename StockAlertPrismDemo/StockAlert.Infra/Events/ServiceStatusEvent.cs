using StockAlert.Infra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlert.Infra.Events
{
    public class ServiceStatusEvent : Microsoft.Practices.Prism.Events.CompositePresentationEvent<ServiceStatus>
    {
    }
}
