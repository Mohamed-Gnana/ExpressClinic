using ExpressClinic.SharedKernal.Domain.Events.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.SharedKernal.Domain.Aggregates
{
    public class BaseEntityWithIntegrationEvents<TId>: BaseEntity<TId>
    {
        public List<BaseIntegrationEvent> IntegrationEvents = new List<BaseIntegrationEvent>();
    }
}
