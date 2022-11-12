using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.SharedKernal.Abstraction.IServices
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
