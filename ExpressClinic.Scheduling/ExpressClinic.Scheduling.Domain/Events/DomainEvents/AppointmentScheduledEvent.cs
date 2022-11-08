using ExpressClinic.Scheduling.Domain.Aggregate;
using ExpressClinic.SharedKernal.Domain.Events.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.Events.DomainEvents
{
    public class AppointmentScheduledEvent: BaseDomainEvent
    {
        public AppointmentScheduledEvent(Appointment appointment)
        {
            ScheduledAppointment = appointment;
        }
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Appointment ScheduledAppointment { get; private set; }
    }
}
