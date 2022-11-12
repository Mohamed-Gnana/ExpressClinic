using Ardalis.GuardClauses;
using ExpressClinic.Scheduling.Domain.Exceptions;
using ExpressClinic.Scheduling.Domain.ScheduleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.ScheduleAggregate.Guards
{
    public static class ScheduleGuardExtension
    {
        public static void DuplicateAppointment(this IGuardClause guardClause, IEnumerable<Appointment> existingAppointments, Appointment newAppointment, string parameterName)
        {
            if (existingAppointments.Any(a => a.Id == newAppointment.Id))
            {
                throw new DuplicateAppointmentException("Cannot add duplicate appointment to schedule.", parameterName);
            }
        }
    }
}
