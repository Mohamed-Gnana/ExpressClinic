using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.Exceptions
{
    public class ClientNotFoundException: Exception
    {
        public ClientNotFoundException(string message): base(message)
        {

        }
        public ClientNotFoundException(int clientId): base($"No Client with id '{clientId}' was found.")
        {

        }
    }
}
