using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.Exceptions
{
    public class PatientNotFoundException: Exception
    {
        public PatientNotFoundException(string message): base(message)
        {

        }
        public PatientNotFoundException(int patientId): base($"No Patient with id '{patientId}' was found.")
        {

        }
    }
}
