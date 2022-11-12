using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Application.ScheduleAggregate.Schedule.Queries.GetEvents
{
    public class GetEventsQuery: IRequest<List<Domain.ScheduleAggregate.Schedule>>
    {

    }
}
