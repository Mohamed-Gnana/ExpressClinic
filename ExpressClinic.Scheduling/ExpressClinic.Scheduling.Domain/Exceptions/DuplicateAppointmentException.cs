using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.Exceptions
{
    public class DuplicateAppointmentException: ArgumentException
    {
        public DuplicateAppointmentException(string message, string parameterName): base(message, parameterName)
        {

        }
    }
}
