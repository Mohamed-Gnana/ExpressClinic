using ExpressClinic.SharedKernal.Domain.Events.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.Events.IntegrationEvents
{
    public class AppointmentConfirmLinkClickedEvent: BaseIntegrationEvent
    {
        public AppointmentConfirmLinkClickedEvent(): this(DateTimeOffset.UtcNow)
        {

        }

        public AppointmentConfirmLinkClickedEvent(DateTimeOffset occurredOn)
        {
            OccuredOn = occurredOn;
        }

        public Guid AppointmentId { get; set; }
        public string EventType
        {
            get
            {
                return nameof(AppointmentConfirmLinkClickedEvent);
            }
        }
    }
}
