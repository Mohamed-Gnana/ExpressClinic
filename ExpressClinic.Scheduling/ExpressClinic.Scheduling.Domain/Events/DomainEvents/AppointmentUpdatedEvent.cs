using ExpressClinic.Scheduling.Domain.ScheduleAggregate;
using ExpressClinic.SharedKernal.Domain.Events.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.Events.DomainEvents
{
    public class AppointmentUpdatedEvent: BaseDomainEvent
    {
        public AppointmentUpdatedEvent(Appointment appointment)
        {
            UpdatedAppointment = appointment;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public Appointment UpdatedAppointment { get; private set; }
    }
}
