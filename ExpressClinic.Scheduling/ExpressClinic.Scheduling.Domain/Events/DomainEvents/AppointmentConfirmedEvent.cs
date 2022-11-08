using ExpressClinic.Scheduling.Domain.Aggregate;
using ExpressClinic.SharedKernal.Domain.Events.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.Events.DomainEvents
{
    public class AppointmentConfirmedEvent: BaseDomainEvent
    {
        public AppointmentConfirmedEvent(Appointment appointment)
        {
            ConfirmedAppointment = appointment;
        }
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Appointment ConfirmedAppointment { get; private set; }
    }
}
