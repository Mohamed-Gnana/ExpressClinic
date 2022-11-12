using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Application.ScheduleAggregate.Schedule.Commands.CreateSchedule
{
    public class CreateScheduleCommand: IRequest<Domain.ScheduleAggregate.Schedule>
    {
        public int ClinicId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Guid> AppointmentIds { get; set; } = new List<Guid>();
    }
}
