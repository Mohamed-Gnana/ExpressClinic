using ExpressClinic.Scheduling.Domain.Events.DomainEvents;
using ExpressClinic.SharedKernal.Abstraction.IServices;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Abstraction.EventsHandlers
{
    public class AppointmentScheduledEventHandler : IRequestHandler<AppointmentScheduledEvent>
    {
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;

        public AppointmentScheduledEventHandler(IEmailSender emailSender, IConfiguration configuration)
        {
            _emailSender = emailSender;
            _configuration = configuration;
        }

        public async Task<Unit> Handle(AppointmentScheduledEvent request, CancellationToken cancellationToken)
        {
            //TODO: get client email from client management service
            await _emailSender.SendEmailAsync("gnana@gmail.com",
                _configuration.GetSection("SystemEmail").Value ?? "system@gmail.com",
                "Appointment Confirmation",
                "Please, Confirm your appointment");

            return Unit.Value;
        }
    }
}
