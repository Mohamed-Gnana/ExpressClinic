using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.Exceptions
{
    public class ScheduleNotFoundException: Exception
    {
        public ScheduleNotFoundException(string message): base(message)
        {

        }
        public ScheduleNotFoundException(Guid scheduleId): base($"No Schedule with id '{scheduleId}' was found.")
        {

        }
    }
}
