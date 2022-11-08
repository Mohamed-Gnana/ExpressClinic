using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.Exceptions
{
    public class DoctorNotFoundException: Exception
    {
        public DoctorNotFoundException(string message): base(message)
        {

        }
        public DoctorNotFoundException(int doctorId): base($"No doctor with id '{doctorId}' was found")
        {

        }
    }
}
