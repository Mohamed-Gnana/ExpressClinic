using ExpressClinic.SharedKernal.Domain.Events.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.Events.IntegrationEvents
{
    public class AppointmentScheduledIntegrationEvent: BaseIntegrationEvent
    {
        public AppointmentScheduledIntegrationEvent()
        {
            OccuredOn = DateTimeOffset.UtcNow;
        }

        public Guid AppointmentId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmailAddress { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string AppointmentType { get; set; }
        public DateTimeOffset AppointmentStartDateTime { get; set; }
        public string EventType => nameof(AppointmentScheduledIntegrationEvent);
    }
}
