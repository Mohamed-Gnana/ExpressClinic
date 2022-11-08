using ExpressClinic.Scheduling.Domain.Aggregate;
using ExpressClinic.SharedKernal.Domain.Events.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.Events.DomainEvents
{
    public class AppointmentDeletedEvent: BaseDomainEvent
    {
        public AppointmentDeletedEvent(Appointment appointment)
        {
            DeletedAppointment = appointment;
        }
        public Guid Id { get; private set; }
        public Appointment DeletedAppointment { get; private set; }
    }
}
