using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.Exceptions
{
    public class AppointmentTypeNotFoundException: Exception
    {
        public AppointmentTypeNotFoundException(string message): base(message)
        {

        }
        public AppointmentTypeNotFoundException(int appointmentTypeId): base($"No Appointment Type with id '{appointmentTypeId}' was found")
        {

        }
    }
}
